namespace Avespoir.AITalk {

	public class SpeakParameter {

		#region Public Property

		public string Text { get; set; } = null;

		public string Kana { get; set; } = null;

		/// <summary>
		/// 音量(0～2)
		/// </summary>
		public double VoiceVolume {
			get {
				return voiceVolume;
			}
			set {
				if (value >= 0 && value <= 2) voiceVolume = value;
			}
		}

		/// <summary>
		/// 話す速度(0.5～4)
		/// </summary>
		public double VoiceSpeed {
			get {
				return voiceSpeed;
			}
			set {
				if (value >= 0.5 && value <= 4) voiceSpeed = value;
			}
		}

		/// <summary>
		/// 話す高さ(0.5～2)
		/// </summary>
		public double VoicePitch {
			get {
				return voicePitch;
			}
			set {
				if (value >= 0.5 && value <= 2) voicePitch = value;
			}
		}

		/// <summary>
		/// 抑揚(0～2)
		/// </summary>
		public double VoiceEmphasis {
			get {
				return voiceEmphasis;
			}
			set {
				if (value >= 0 && value <= 2) voiceEmphasis = value;
			}
		}

		/// <summary>
		/// 短いポーズのときの時間(ミリ秒) (80～500 かつ PauseLong以下)
		/// </summary>
		/// <remarks>
		/// 値を変えたい場合は<see cref="SetPauseMiddleLong(int?, int?)"/>を使います
		/// </remarks>
		public int PauseMiddle {
			get {
				return pauseMiddle;
			}
		}

		/// <summary>
		/// 長いポーズのときの時間(ミリ秒) (100～2000 かつ PauseMiddle以上)
		/// </summary>
		/// <remarks>
		/// 値を変えたい場合は<see cref="SetPauseMiddleLong(int?, int?)"/>を使います
		/// </remarks>
		public int PauseLong {
			get {
				return pauseLong;
			}
		}

		/// <summary>
		/// 終了時のポーズ時間(ミリ秒) (0～10000)
		/// </summary>
		public int PauseSentence {
			get {
				return pauseSentence;
			}
			set {
				if (value >= 0 && value <= 10000) pauseSentence = value;
			}
		}

		/// <summary>
		/// かな変換時のタイムアウト時間(ミリ秒) (0で無制限)
		/// </summary>
		public int ConvertKanaTimeout {
			get {
				return convertKanaTimeout;
			}
			set {
				if (value >= 0) convertKanaTimeout = value;
			}
		}

		/// <summary>
		/// 音声変換時のタイムアウト時間(ミリ秒) (0で無制限)
		/// </summary>
		public int ConvertTextTimeout {
			get {
				return convertTextTimeout;
			}
			set {
				if (value >= 0) convertTextTimeout = value;
			}
		}

		#endregion

		#region Private Firld

		private double voiceVolume = double.NaN;

		private double voiceSpeed = double.NaN;

		private double voicePitch = double.NaN;

		private double voiceEmphasis = double.NaN;

		private int pauseMiddle = -1;

		private int pauseLong = -1;

		private int pauseSentence = -1;

		private int convertKanaTimeout = 0;

		private int convertTextTimeout = 0;

		#endregion

		/// <summary>
		/// <see cref="PauseMiddle"/>と<see cref="PauseLong"/>の値をsetします
		/// </summary>
		/// <param name="pause_middle">短いポーズのときの時間(ミリ秒) (80～500 かつ PauseLong以下) <see cref="null"/>の場合すでに入っている<see cref="PauseMiddle"/>の値が使用されます</param>
		/// <param name="pause_long">長いポーズのときの時間(ミリ秒) (100～2000 かつ PauseMiddle以上) <see cref="null"/>の場合すでに入っている<see cref="PauseLong"/>の値が使用されます</param>
		/// <returns>成功した場合は<see cref="true"/>, 失敗した場合は<see cref="false"/>が返されます</returns>
		public bool SetPauseMiddleLong(int? pause_middle = null, int? pause_long = null) {
			int pause_middle_ = pause_middle is int x ? x : PauseMiddle;
			int pause_long_ = pause_long is int y ? y : PauseLong;

			if (pause_middle_ > pause_long_) return false;
			if (pause_middle_ < 80 | pause_middle_ > 500) return false;
			if (pause_long_ < 100 | pause_long_ > 2000) return false;

			pauseMiddle = pause_middle_;
			pauseLong = pause_long_;

			return true;
		}
	}
}
