using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Avespoir.AITalk.Test {

	public class GenerateTest {

		/*
		 Aitalk��x86�ł������삵�Ȃ��̂�Avespoir.AITalk��Avespoir.AITalk.Test��
		 �S�Ă�x86�ɂȂ��Ă��Ȃ��ꍇ��΂ɓ��삵�Ȃ�
		 �������v���O������x64��Any CPU�œ��삳�������ꍇAitalk�̃V�X�e����
		 �O���Ɉ��������K�v������
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

				speakParameter.Text = "�Ă��Ƃ���";

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
