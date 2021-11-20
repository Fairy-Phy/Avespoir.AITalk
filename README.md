> ### フォークについて
> このフォークは[Avespoir Bot](https://github.com/Fairy-Phy/Avespoir)に搭載する用に改変をしています。
>
> HTTPサーバーデーモンの機能を排除してBotに組込しやすいようにしてあるため[元レポジトリ](https://github.com/Nkyoku/voiceroid_daemon)とはほとんど互換性がありません。
> 
> なのでこれについて気になる場合はこのレポジトリよりも[元レポジトリ](https://github.com/Nkyoku/voiceroid_daemon)を見たほうが良いです。
> 
> それによって名前を``Avespoir.AITalk``に変更しました

# Avespoir.AITalk
botでvoiceroidを動かすための簡易ライブラリ


## 概要
VOICEROID2のDLL(aitalked.dll)を直接叩いて、音声データをHTTPで取得できるサーバーソフトです。  
よってエディターを起動しておく必要はありません。  
ライセンス認証はDLLレベルで行われているため当然ながら動作には有効なライセンスが必要です。  

Avespoir.AITalkはvoiceroid_daemonに搭載されていたAiTalkライブラリを使ってbotから参照できるようにしたものです。

元レポジトリ: https://github.com/Nkyoku/voiceroid_daemon

## ビルド環境
Visual Studio 2019

## スピーチパラメータ
読み仮名変換や音声変換はURLリクエストの形で指定する他、JSON形式のテキストをPOSTすることでも行えます。  
以下にフォーマットを示します。  
```
{
  "Text" : <読み仮名あるいは音声に変換する文章>,
  "Kana" : <音声に変換する読み仮名>,
  "Speaker" : {
    "Volume" : <音量 (0～2)>,
	"Speed" : <話速 (0.5～4)>,
	"Pitch" : <高さ (0.5～2)>,
	"Emphasis" : <抑揚 (0～2)>,
	"PauseMiddle" : <短ポーズ時間[ms] (80～500) PauseLong以下>,
	"PauseLong" : <長ポーズ時間[ms] (100～2000) PauseMiddle以上>,
	"PauseSentence" : <文末ポーズ時間[ms] (0～10000)>
  }
}
```
指定しないパラメータは省略できます。その場合、ボイスライブラリの初期値が使用されます。  
また、`Volume`, `Speed`, `Pitch`, `Emphasis`はNaNを指定すると初期値が、  
`PauseMiddle`, `PauseLong`, `PauseSentence`は-1を指定すると初期値が使用されます。

## ライセンス
本ソフトウェアの製作にあたって以下のライブラリを使用しています。  
- [Friendly](https://github.com/Codeer-Software/Friendly)  

元レポジトリはMITライセンスです
