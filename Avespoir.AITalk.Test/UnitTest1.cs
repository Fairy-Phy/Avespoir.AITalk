using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Avespoir.AITalk.Test {

	public class UnitTest1 {

		private readonly ITestOutputHelper testOutputHelper;

		const string DllPath = @"C:/Program Files (x86)/AHS/VOICEROID2";

		const string Seed = "ORXJC6AIWAUKDpDbH2al";

		public UnitTest1(ITestOutputHelper TestOutputHelper) {
			testOutputHelper = TestOutputHelper;
		}

		[Fact]
		public void Test1() {
			using (Voiceroid2 voiceroid2 = new Voiceroid2(DllPath, Seed)) {
				SpeakParameter speakParameter = new SpeakParameter();

				speakParameter.Text = "‚±‚ñ‚É‚¿‚Í";

				Assert.True(voiceroid2.TextToKana(speakParameter));
				testOutputHelper.WriteLine(speakParameter.Kana);

				using MemoryStream resS = voiceroid2.KanaToPCM(speakParameter);

				byte[] res = resS.ToArray();

				Guid guid = Guid.NewGuid();
				using FileStream SaveFile = new FileStream($"./{guid}", FileMode.Create, FileAccess.Write);
				SaveFile.Write(res);
			}
		}
	}
}
