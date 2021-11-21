using Aitalk;
using System;
using System.IO;
using System.Linq;

namespace Avespoir.AITalk {

	public class Voiceroid2 : IDisposable {

		/*
			LanguageName = "standard";
			PhraseDictionaryPath = "";
			WordDictionaryPath = "";
			SymbolDictionaryPath = "";
		 */

		private SpeakParameter DefaultSpeakParam;

		/// <summary>
		/// ボイスロイドの初期化処理
		/// </summary>
		/// <param name="DllDirPath">aitalked.dllのディレクトリパス、そのディレクトリパスにVoiceやらが含まれてる必要があります</param>
		/// <param name="SeedCode">dllの認証コードシード</param>
		public Voiceroid2(string DllDirPath, string SeedCode) {
			if (!Directory.Exists(DllDirPath)) throw new DirectoryNotFoundException();

			AitalkWrapper.Initialize(DllDirPath, SeedCode);

			// 基本はstanderd?
			string language_name = AitalkWrapper.LanguageList.FirstOrDefault() ?? "";
			AitalkWrapper.LoadLanguage(language_name);

			// ここからの処理は各サーバー設定によって設定できるようにするか考える

			/*
			// フレーズ辞書が指定されていれば読み込む
			if (File.Exists(PhraseDictionaryPath)) {
				AitalkWrapper.ReloadPhraseDictionary(PhraseDictionaryPath);
			}

			// 単語辞書が指定されていれば読み込む
			if (File.Exists(WordDictionaryPath)) {
				AitalkWrapper.ReloadWordDictionary(WordDictionaryPath);
			}

			// 記号ポーズ辞書が指定されていれば読み込む
			if (File.Exists(SymbolDictionaryPath)) {
				AitalkWrapper.ReloadSymbolDictionary(SymbolDictionaryPath);
			}
			*/

			// ボイスライブラリの読み込み //
			// ボイスライブラリ名:VoiceDbName と 話者名:SpeakerName はどちらもボイスライブラリの名前だと思う

			// 仮 確定でelse
			string VoiceDbName = "", SpeakerName = "";
			if (0 < VoiceDbName.Length) {
				string voice_db_name = VoiceDbName;
				AitalkWrapper.LoadVoice(voice_db_name);

				// 話者が指定されているときはその話者を選択する
				if (0 < SpeakerName.Length) {
					AitalkWrapper.Parameter.CurrentSpeakerName = SpeakerName;
				}
			}
			else {
				// 未指定の場合、初めに見つけたものを読み込む
				string voice_db_name = AitalkWrapper.VoiceDbList.FirstOrDefault() ?? "";
				AitalkWrapper.LoadVoice(voice_db_name);
			}

			// 話者パラメータの初期値を記憶する
			DefaultSpeakParam = new SpeakParameter {
				VoiceVolume = AitalkWrapper.Parameter.VoiceVolume,
				VoiceSpeed = AitalkWrapper.Parameter.VoiceSpeed,
				VoicePitch = AitalkWrapper.Parameter.VoicePitch,
				VoiceEmphasis = AitalkWrapper.Parameter.VoiceEmphasis,
				PauseSentence = AitalkWrapper.Parameter.PauseSentence
			};
			if (!DefaultSpeakParam.SetPauseMiddleLong(AitalkWrapper.Parameter.PauseMiddle, AitalkWrapper.Parameter.PauseLong))
				throw new AitalkException("初期値がおかしいです");
		}

		/// <summary>
		/// テキストをかなに変換します
		/// </summary>
		/// <param name="SpeakParam">パラメータ</param>
		/// <returns><see cref="SpeakParameter.Kana"/>に結果が入り<see cref="true"/>を返します、問題が発生した場合はnullが入り<see cref="false"/>を返します</returns>
		public bool TextToKana(SpeakParameter SpeakParam) {
			try {
				if ((SpeakParam.Text == null) || (SpeakParam.Text.Length <= 0))
					return false;
				SpeakParam.Kana = AitalkWrapper.TextToKana(SpeakParam.Text, SpeakParam.ConvertKanaTimeout);

				// もう一度検査
				if ((SpeakParam.Text == null) || (SpeakParam.Text.Length <= 0))
					return false;
				return true;
			}
			catch (Exception) { }

			return false;
		}

		// Discordで流すためには品質維持のためにも48kHz, 16bit, ステレオにする必要がある...
		// ここはffmpegで変換するしか無いのか

		/// <summary>
		/// かな文字からPCMに変換します
		/// </summary>
		/// <remarks>
		/// PCMは44.1khz, 16bit, モノラルです
		/// </remarks>
		/// <param name="SpeakParam">パラメータ</param>
		public MemoryStream KanaToPCM(SpeakParameter SpeakParam) {
			try {
				AitalkWrapper.Parameter.VoiceVolume =
					SpeakParam.VoiceVolume >= 0 && SpeakParam.VoiceVolume <= 2 ? SpeakParam.VoiceVolume : DefaultSpeakParam.VoiceVolume;
				AitalkWrapper.Parameter.VoiceSpeed =
					SpeakParam.VoiceSpeed >= 0.5 && SpeakParam.VoiceSpeed <= 4 ? SpeakParam.VoiceSpeed : DefaultSpeakParam.VoiceSpeed;
				AitalkWrapper.Parameter.VoicePitch =
					SpeakParam.VoicePitch >= 0.5 && SpeakParam.VoicePitch <= 2 ? SpeakParam.VoicePitch : DefaultSpeakParam.VoicePitch;
				AitalkWrapper.Parameter.VoiceEmphasis =
					SpeakParam.VoiceEmphasis >= 0 && SpeakParam.VoiceEmphasis <= 2 ? SpeakParam.VoiceEmphasis : DefaultSpeakParam.VoiceEmphasis;
				AitalkWrapper.Parameter.PauseMiddle =
					SpeakParam.PauseMiddle >= 80 && SpeakParam.PauseMiddle <= 500 ? SpeakParam.PauseMiddle : DefaultSpeakParam.PauseMiddle;
				AitalkWrapper.Parameter.PauseLong =
					SpeakParam.PauseLong >= 100 && SpeakParam.PauseLong <= 2000 ? SpeakParam.PauseLong : DefaultSpeakParam.PauseLong;
				AitalkWrapper.Parameter.PauseSentence =
					SpeakParam.PauseSentence >= 0 && SpeakParam.PauseSentence <= 10000 ? SpeakParam.PauseSentence : DefaultSpeakParam.PauseSentence;

				string kana = null;
				if ((SpeakParam.Kana != null) && (0 < SpeakParam.Kana.Length))
					kana = SpeakParam.Kana;
				else if ((SpeakParam.Text != null) && (0 < SpeakParam.Text.Length))
					if (TextToKana(SpeakParam))
						kana = SpeakParam.Kana;
					else throw new AitalkException("かな変換できませんでした");
				else throw new ArgumentNullException(nameof(SpeakParam.Text));

				MemoryStream ResStream = new MemoryStream();
				AitalkWrapper.KanaToSpeechPCM(kana, ResStream, SpeakParam.ConvertTextTimeout);
				return ResStream;
			}
			catch (Exception) {
				return null;
			}
		}

		void IDisposable.Dispose() {
			// まあ必要ない気がするが...
			AitalkWrapper.Finish();
		}
	}
}
