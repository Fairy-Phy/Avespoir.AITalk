using System;
using System.Reflection;
using System.Diagnostics;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Dynamic;

namespace Injecter
{
    /// <summary>
    /// VOICEROID2エディタにDLLインジェクションするクラス
    /// </summary>
    public class Injecter
    {
        /// <summary>
        /// 認証コードを取得する。
        /// VOICEROID2エディタが実行中である必要がある。
        /// </summary>
        /// <returns>認証コードのシード値</returns>
        public static string GetKey(string process_name)
        {
            // VOICEROIDエディタのプロセスを検索する
            Process[] voiceroid_processes = Process.GetProcessesByName(process_name);
            if (voiceroid_processes.Length == 0)
            {
                return null;
            }
            Process process = voiceroid_processes[0];

            // プロセスに接続する
            // ここはx86でコンパイルしないと正常に動作しない
            // Codeer.Friendly.FriendlyOperationException
            WindowsAppFriend app = new WindowsAppFriend(process);
            WindowsAppExpander.LoadAssembly(app, typeof(Injecter).Assembly);
            dynamic injected_program = app.Type(typeof(Injecter));
            try
            {
                // 認証コードを読み取って返す
                return injected_program.InjectedGetKey();
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// 認証コードの取得のためにDLLインジェクション先で実行されるコード
        /// </summary>
        /// <returns></returns>
        private static string InjectedGetKey()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                /*
                    AI.Framework.App.dllが存在しないため他のライブラリから参照できるように修正
                 */
                if (assembly.GetName().Name == "AI.Talk.Editor.Core")
                {
                    Type type = assembly.GetType("AI.Talk.Editor.Settings.AppSettings");
                    var property = type.GetProperty("Current");
                    dynamic current = property.GetValue(type);
                    return (string) current.LicenseKey;
                }
            }
            return null;
        }
    }
}
