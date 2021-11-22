﻿using Avespoir.AITalk;
using System;
using System.IO;

namespace ConsoleApp1 {
	class Program {

		const string DllPath = @"C:/Program Files (x86)/AHS/VOICEROID2";

		const string Seed = "ORXJC6AIWAUKDpDbH2al";

		static void Main(string[] args) {
			using (Voiceroid2 voiceroid2 = new Voiceroid2(DllPath, Seed)) {
				SpeakParameter speakParameter = new SpeakParameter();

				speakParameter.Text = "兵庫県の川西市役所の庁舎内に盗聴器が仕掛けられていたことが明らかになりました。盗聴器は入札に関連する部署の近くで見つかり、事態を重く見た市は警察に被害届を提出したということです。10月26日、市役所の庁舎から不審な電波が発信されていることをTBS系の番組スタッフが見つけ、市役所に届け出ました。11月3日に番組スタッフと盗聴被害の調査会社らが庁舎内を調べたところ、4階フロアの総務部のキャビネット上にあった電源プラグを差し込むタップ部分に盗聴器が仕掛けられているのを発見したということです。盗聴器はプラグの分配器の形状をしていて、分解すると中から発信器などが見つかりました。4階には市長室や総務部などがありますが、盗聴器が見つかったすぐ近くには秘密の情報がやりとりされる『入札関連の部署』もあります。市によりますと、調査会社は『盗聴機器は一般に販売されているもので、機器内部の状況から最大1年前から設置されていたと思われる』と話しているということです。また、この機器から発信された電波は庁舎から半径200mの範囲でも拾えるということです。川西市は「盗聴機器が設置されていたのは、不特定多数の職員が自由に出入りできる場所であり、ここで機密や個人情報に関する会話はまず行われていない」ということです。また、川西市の越田謙治郎市長は「盗聴機器が設置されていた場所から考えますと、市の機密情報や市民の個人情報が漏洩した可能性は薄いと判断しています」とコメントしています。事態を重く見た市は警察に被害届を提出したということです。被害が明確になっていないことから、警察では何者かが市役所に不法に侵入した建造物侵入容疑で捜査しています。政府が経済安全保障の強化に向け、盗聴が不可能とされる「量子暗号通信」の研究開発を加速する。令和３年度補正予算案に約１４５億円を計上し、実証実験や人工衛星の活用などを進める方針だ。量子暗号通信をめぐっては、覇権主義的な行動を強める中国が実用化で日本などに先行している。岸田文雄政権としては、機微技術の一つである量子暗号通信の早期実用化を後押しすることで、経済安保や新産業の育成につなげる狙いがある。量子暗号通信は、電子や光など極小の物質の世界で起きる現象を利用した技術。重要な文書や画像などのデータを暗号化し、解読に必要な使い捨ての「鍵」を素粒子の一つである光子（光の粒）に乗せて送受信する。光子はこれ以上分割できない性質があるため、第三者が送信の途中で盗み見して鍵が壊れると複製が不可能になり、鍵の盗聴に気付く仕組みだ。軍事転用される可能性があり、経済安保の観点から機微技術として注目されている。総務省は補正予算案で経済安保に約２５０億円を計上した。このうち約１４５億円を量子暗号通信の研究開発推進に充てる。具体的には、国立研究開発法人の情報通信研究機構に「テストベッド」と呼ばれる実証実験環境を整備する事業に約９０億円を計上。多数の人工衛星を協調して運用する「衛星コンステレーション」での量子暗号通信の活用のために約５０億円を投じる。産官学の連携で、技術開発を加速させる狙いだ。日本は量子技術の基礎研究で優位性を発揮してきたが、戦略投資を進める中国と比べ、実用化が遅れているとされる。首相は、量子暗号通信について、経済安保に加え、日本の新たな成長分野としても期待をかける。１９日の産経新聞などのインタビューでは「量子暗号などは日本が世界をリードできるポテンシャルのある分野だ。国として優先的に研究資金を投入する」と述べた。政府は４月の菅義偉前首相とバイデン米大統領との会談でも量子技術の研究開発での協力を確認しており、今後、同盟国との連携なども重要になる。今日22日(月)は前線が日本列島を通過するため、全国的に雨が降ります。前線通過時は強い雨や雷、突風に注意が必要です。沿岸部を中心に風が強まり、横殴りの雨になることもあります。また、雨の後は北寄りの風に変わり、気温が大幅に下がる予想です。低気圧からのびる前線が日本列島を通過します。全国的に雨が降り、前線通過時は雷を伴った激しい雨や突風に注意が必要です。特に九州や中国・四国は朝に雨が強まります。通勤・通学は時間に余裕を持って行動するようにしてください。関東や東北太平洋側は、前線接近前から風の衝突による雨雲が広がり、雨が降ったり止んだりの一日。夕方から夜は前線通過により、雨が強まる予想です。低気圧が発達しながら東へ進むため、沿岸部を中心に風が強まります。特に、低気圧に近い北海道は瞬間的には35m/sを超える暴風となるおそれがあり、荒れた天気に警戒が必要です。交通機関に影響が出るおそれもあるため、こまめに最新の情報を確認するようにしてください。前線に向かって南から暖かい空気が流れ込むため、朝は比較的過ごしやすいところが多くなります。ただ、前線通過後は冷たい空気が流れ込むため、気温が大幅に下がる予想です。雨の止むタイミングが早い西日本は気温が右肩下がりで、夜は厚手の上着が必要な寒さになります。急激な体感変化で体調を崩さないようお気を付けください。";

				if (!voiceroid2.TextToKana(speakParameter))
					throw new Exception();
				Console.WriteLine(speakParameter.Kana);

				using MemoryStream resS = voiceroid2.KanaToDiscordPCM(speakParameter);

				byte[] res = resS.ToArray();

				Guid guid = Guid.NewGuid();
				using FileStream SaveFile = new FileStream($"./{guid}", FileMode.Create, FileAccess.Write);
				SaveFile.Write(res);
			}
		}
	}
}
