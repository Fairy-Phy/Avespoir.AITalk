using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Avespoir.AITalk.Test {

	public class GenerateTest {

		/*
		 Aitalkがx86でしか動作しないのでAvespoir.AITalkもAvespoir.AITalk.Testも
		 全てかx86になっていない場合絶対に動作しない
		 もし元プログラムをx64かAny CPUで動作させたい場合Aitalkのシステムを
		 外部に引き離す必要がある
		 */

		private readonly ITestOutputHelper testOutputHelper;

		const string DllPath = @"C:/Program Files (x86)/AHS/VOICEROID2";

		const string Seed = "ORXJC6AIWAUKDpDbH2al";

		public GenerateTest(ITestOutputHelper TestOutputHelper) {
			testOutputHelper = TestOutputHelper;
		}

		[Fact]
		public void Test() {
			using (Voiceroid2 voiceroid2 = new Voiceroid2(DllPath, Seed)) {
				SpeakParameter speakParameter = new SpeakParameter();

				speakParameter.Text = "てすとだよ";

				Assert.True(voiceroid2.TextToKana(speakParameter));
				testOutputHelper.WriteLine(speakParameter.Kana);

				using MemoryStream resS = voiceroid2.KanaToDiscordPCM(speakParameter);

				byte[] res = resS.ToArray();

				Guid guid = Guid.NewGuid();
				using FileStream SaveFile = new FileStream($"./{guid}", FileMode.Create, FileAccess.Write);
				SaveFile.Write(res);
			}
		}
	}
}
