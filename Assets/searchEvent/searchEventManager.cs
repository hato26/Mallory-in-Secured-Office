using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class searchEventManager : MonoBehaviour
{

    // リザルトシーン名　(定数)
    const string GAME_SCENE_RESULT = "ResultScene";

    // UIの ON or OFF (定数)
    private const string UI_ON = "ON";
    private const string UI_OFF = "OFF";

    //グローバル変数 プレイヤー調査範囲
    int[][] playersSearchData;

    // UIマネージャーの獲得
    private UIManager uiManager;

    // マップ情報
    private GameObject door;
    private doorController doorController;
    private bool openDoorFlag = false; // ドアが開いているかどうか

    // 田中のデスクに関するイベント
    private TanakaDesk tanakaDesk;
    //private bool tanakaBookSearchFlag = false; // 田中デスクの本を調べたかどうか

    // 入力されたパスワードが正しいかどうかの保持
    private bool tanakaPcPasswordFlag = false;

    // パスワードデータベースの獲得
    private PasswordManager passwordManager;
    private string getPasswordDataID = ""; // 獲得したいパスワードデータのパスワードIDを保持
    string doorPasswordID = "PASS_EXIT" ; // ドアのパスワードID

    // 獲得したパスワードデータ
    private PasswordData passwordData;

    // パスワードの獲得時メッセージ用変数
    private string characterName = "マロリー";
    private string beforeText = ""; // 獲得前テキスト
    private string afterText = ""; // 獲得後テキスト

    // スコアデータマネージャー
    private ScoreDataManager scoreDataManager;
    



    // コンストラクタ
    private searchEventManager(){}


    // 初期化用メソッド
    public void initializeSearchEventManager(int[][] searchData){

        //値の初期化
        this.playersSearchData = searchData;

        // マップデータ
        this.door = GameObject.Find("Exit");
        this.doorController = this.door.GetComponent<doorController>();

        // 田中のデスクに関するイベント
        this.tanakaDesk = new TanakaDesk();

        // UIマネージャーの獲得
        GameObject uiManager_obj = GameObject.Find("UIManager");
        this.uiManager = uiManager_obj.GetComponent<UIManager>();

        // パスワードマネージャー(データベース)の獲得
        GameObject passwordManager_obj = GameObject.Find("PasswordManager");
        this.passwordManager = passwordManager_obj.GetComponent<PasswordManager>();

        // ドアのパスワードの初期化
        PasswordData doorPass = this.passwordManager.getPasswordData(this.doorPasswordID);
        this.doorController.setDoorPasswordData(doorPass);

        // スコアデータマネージャーの獲得
        GameObject scoreDataManager_obj = GameObject.Find("ScoreDataManager");
        this.scoreDataManager = scoreDataManager_obj.GetComponent<ScoreDataManager>();

    }

     // プレイヤーの調査イベント番号の獲得
    public int getSearchEventNumber(Vector2Int index){

        int[][] data = this.playersSearchData;

        int elem = data.Length;
        int column = data[0].Length;
        int num = 0;

        // 参照エラーの対策
        if( (index.x >= 0 && index.x < column) && (index.y >= 0 && index.y < elem)){
            num = data[index.y][index.x];
        }

        return num;
    }

    // 調査イベントの発生
    public void searchEvent(int num){

        switch(num){

            // 何もないとき
            case 0:
                Debug.Log("調べられないよ！");
            break;

            // 本を調べたとき
            case 1:
                Debug.Log("これは本です");
            break;

            // 植木を調べたとき
            case 2:
                Debug.Log("緑だなぁ〜");
            break;

            // サーバーを調べたとき
            case 3:

                this.setBeforeText("サーバーコンピュータの上においてある　メモ用紙に　なにか書いてある"); // 獲得メッセージの表示前に表示するテキスト
                this.setAfterText("メモ用紙をおきっぱには　しないほうがいいよね…"); // 獲得メッセージの表示後に表示するテキスト
                this.setPasswordDataID("PASS_SERVER_1");
                StartCoroutine(this.getPasswordDataCoroutine()); // パスワード入力待機用コルーチン

            break;

            // 電話を調べたとき
            case 4:
                Debug.Log("電話が鳴っていない…");
            break;

            // ホワイトボードを調べたとき 
            case 20:

                this.setBeforeText("ホワイトボードに　何か書いてある"); // 獲得メッセージの表示前に表示するテキスト
                this.setAfterText("文字数がすくないし　数字だけのパスワードは　バレやすいよね…"); // 獲得メッセージの表示後に表示するテキスト
                this.setPasswordDataID("PASS_BOARD_1");
                StartCoroutine(this.getPasswordDataCoroutine()); // パスワード入力待機用コルーチン
            
            break;

            // ホワイトボードを調べたとき 2
            case 21:

                this.setBeforeText("ホワイトボードに　何か書いてある"); // 獲得メッセージの表示前に表示するテキスト
                this.setAfterText("だいじな情報は　書いたままにしちゃダメだね…"); // 獲得メッセージの表示後に表示するテキスト
                this.setPasswordDataID("PASS_BOARD_2");
                StartCoroutine(this.getPasswordDataCoroutine()); // パスワード入力待機用コルーチン

            break;

            // ゴミ箱を調べたとき 1
            case 22:
            
                this.setBeforeText("くしゃくしゃになって　捨てられた紙に　何か書いてある"); // 獲得メッセージの表示前に表示するテキスト
                this.setAfterText("書いてあることがわかるじょうたいで　捨てちゃダメだよ…"); // 獲得メッセージの表示後に表示するテキスト
                this.setPasswordDataID("PASS_DUST_1");
                StartCoroutine(this.getPasswordDataCoroutine()); // パスワード入力待機用コルーチン
            
            break;

            // ゴミ箱を調べたとき 2
            case 23:

                this.setBeforeText("しゃくしゃになって　捨てられた紙に　何か書いてある"); // 獲得メッセージの表示前に表示するテキスト
                this.setAfterText("ちゃんとシュレッダーにかけて　バラバラにしないと…"); // 獲得メッセージの表示後に表示するテキスト
                this.setPasswordDataID("PASS_DUST_2");
                StartCoroutine(this.getPasswordDataCoroutine()); // パスワード入力待機用コルーチン

            break;





            // ドアを調べたとき
            case 50:

                // ゲームをクリアしたかどうか クリアしたときリザルトシーンへ
                this.gameClearChecker();

            break;

            // 田中のディスクの本を調べたとき
            case 60:

                if(this.tanakaPcPasswordFlag){ // ログイン後
                    // なにもしない
                }
                else{ // ログイン前
                    this.uiManager.tanakaDeskBookText(); // 田中のディスクの本を調べたときの台詞を表示
                    this.getPasswordData("PASS_TANAKA");
                    string searchMessage = this.tanakaDesk.getSearchBookMessage();
                    Debug.Log(searchMessage);
                }

            break;

            // 田中のディスクのPCを調べたとき
            case 61:

                this.searchTanakaPC(); // 田中のディスクのPCを調べたとき

            break;

            // Aのディスクの電話を調べたとき
            case 70:
                // なし
            break;

            // Aのディスクのファイルを調べたとき
            case 71:

                this.setBeforeText("ファイルに閉じられていた紙に　なにかのパスワードが書いてある"); // 獲得メッセージの表示前に表示するテキスト
                this.setAfterText("ほかの人から見られる場所に　だいじな情報をおくのは　よくないね…"); // 獲得メッセージの表示後に表示するテキスト
                this.setPasswordDataID("PASS_1");
                StartCoroutine(this.getPasswordDataCoroutine()); // パスワード入力待機用コルーチン

            break;

            // BのディスクのPCを調べたとき
            case 80:

                this.setBeforeText("モニターの前においてある手帳に　なにかのパスワードが書いてある"); // 獲得メッセージの表示前に表示するテキスト
                this.setAfterText("自分いがいの個人情報ものっているかもしれないから　ちゃんとなくさないよう管理しないと…"); // 獲得メッセージの表示後に表示するテキスト
                this.setPasswordDataID("PASS_2");
                StartCoroutine(this.getPasswordDataCoroutine()); // パスワード入力待機用コルーチン

            break;

            // Dのディスクのファイルを調べたとき
            case 90:

                this.setBeforeText("ファイルにはってある　ふせんに　なにかのパスワードが書いてある"); // 獲得メッセージの表示前に表示するテキスト
                this.setAfterText("ながいパスワードでも\n数字だけでつくらないほうがいいね…"); // 獲得メッセージの表示後に表示するテキスト
                this.setPasswordDataID("PASS_BINDER_1");
                StartCoroutine(this.getPasswordDataCoroutine()); // パスワード入力待機用コルーチン

            break;

            // EのディスクのPCを調べたとき
            case 91:

                this.setBeforeText("パソコンにはってある　ふせんに　何か書いてある"); // 獲得メッセージの表示前に表示するテキスト
                this.setAfterText("パスワードは分かりにくいのに\nふせんを貼ったままにしておくのは　マズいよね…"); // 獲得メッセージの表示後に表示するテキスト
                this.setPasswordDataID("PASS_EXIT"); // 獲得したいパスワードデータのパスワードIDを保持
                StartCoroutine(this.getPasswordDataCoroutine()); // パスワード入力待機用コルーチン

            break;

            // 上記以外のとき
            default:
                Debug.Log("未定義動作です");
            break;
        }


    }


    // ===========田中イベント============

    // 田中のディスクのPCを調べたとき
    private void searchTanakaPC(){

        // 入力パスワードがfalseのとき
        if(!this.tanakaPcPasswordFlag){

            StartCoroutine(this.inputPasswordCoroutine());// パスワード入力待機用コルーチン

        }
        else{ // 入力パスワードが真のとき

            // 田中PCのログイン後UIの表示等の処理
            Debug.Log("SEM : 田中PCログイン中");

            StartCoroutine(this.passwordCrackCoroutine());// パスワードクラック待機用コルーチン

        }

    }

    // 田中のパスワードチェック 正しいときtrue
    private bool searchTanakaPCPasswordChecker(){

        bool passwordFlag = false;

        string inputPassword = this.uiManager.getInputPassword(); // パスワードの獲得
        passwordFlag = this.tanakaDesk.passwordChecker(inputPassword);  // パスワードが正しいかどうかの判定

        return passwordFlag;
    }

    // 入力待機用コルーチン
    private IEnumerator inputPasswordCoroutine(){

        // 待機時間(ローカル定数)
        const float DELAY_TIME = 1.0f;

        this.uiManager.inputPasswordUISwitch(UI_ON); // パスワード入力用UIの表示ON
        Debug.Log(this.uiManager.getInputEndFlag());

        yield return new WaitUntil( () => this.uiManager.getInputEndFlag() );// strueのとき処理を進める
        yield return null; // 1フレーム待つ

        this.scoreDataManager.incrementNumberOfAttacksOnTanakaPC(); // 田中PCへのアタック回数を更新

        this.tanakaPcPasswordFlag = this.searchTanakaPCPasswordChecker(); // 入力されたパスワードのチェック

        this.uiManager.inputPasswordUISwitch(UI_OFF); // パスワード入力用UIの表示OFF

        this.uiManager.inputRcockSwitch(); // 入力制のオン
        yield return new WaitForSeconds(DELAY_TIME); // 数秒待つ
        yield return null; // 1フレーム待つ 
        this.uiManager.inputRcockSwitch(); // 入力制のオフ

        // 入力パスワードが正しいとき　ログイン後UIの表示等
        if(this.tanakaPcPasswordFlag){

            this.uiManager.correctPasswordText(); // テキストを表示
            StartCoroutine(this.passwordCrackCoroutine()); // パスワードクラック待機用コルーチン
        
        }
        else{ // 正しくないとき
            this.uiManager.lncorrectPasswordText(); // テキストを表示
        }

    }


    // 田中PCにログインした後の処理

    // 田中PCログイン中(パスワードクラック)のコルーチン
    private IEnumerator passwordCrackCoroutine(){

        // 待機時間(ローカル定数)
        const float DELAY_TIME = 2.0f;

        if(this.openDoorFlag){ // ドアが開いているとき
            Debug.Log("出口は開いている");
        }
        else{ // ドアが閉まっているとき

            this.uiManager.passwordCrackUISwitch(UI_ON); // パスワードクラックUIの表示ON

            yield return new WaitWhile( () => this.uiManager.getGeneralUITextEndFlag() ); // falseのとき処理を進める 台詞の表示が終わるまで待つ
            yield return null; // 1フレーム待つ

            yield return new WaitUntil( () => this.uiManager.getCreateListFlag() ); // trueのとき処理を進める リストを作るまで待つ
            yield return null; // 1フレーム待つ

            this.uiManager.passwordCrackButtonSwitch(UI_ON); // ボタンを有効

            yield return new WaitUntil( () => this.uiManager.getAttackFlag() ); // trueのとき処理を進める
            yield return null; // 1フレーム待つ

            this.uiManager.passwordCrackButtonSwitch(UI_OFF); // ボタンを無効
            this.uiManager.restCreateFlag(); // パスワードリストを作っていない状態にする

            this.scoreDataManager.incrementNumberOfPasswordListbasedAttack(); // パスワードリスト攻撃の回数を更新

            this.uiManager.passwordCrackUISwitch(UI_OFF); // パスワードクラックUIの表示OFF

            // 獲得済みパスワードの正誤判定　正しいパスワードが含まれているとき真
            string[] getPasswordArray = this.passwordManager.getPasswordGetArray();
            bool openFlag = this.doorController.passwordChecker(getPasswordArray);

            // ドアを開けるときのテキストを表示
            if(openFlag){ // 開けるとき

                string text = ""; // 表示テキストの格納

                this.uiManager.generalUISwitchDirect(UI_ON); // テキスト表示用UIオン

                this.uiManager.setGeneralUICharacterImage("Mallory", "SURPRISE"); // イメージの表示
                text = "よし！";
                this.uiManager.setGeneralUIText(this.characterName, text); // 獲得前メッセージの表示

                yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
                yield return null; // 1フレーム待つ

                this.uiManager.setGeneralUICharacterImage("Mallory", "HAPPY"); // イメージの表示
                text = "管理コンピュータにアクセスできたぞ！";
                this.uiManager.setGeneralUIText(this.characterName, text); // 獲得前メッセージの表示

                yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
                yield return null; // 1フレーム待つ

                this.uiManager.setGeneralUICharacterImage("Mallory", "EXCITED"); // イメージの表示
                text = "あとは…";
                this.uiManager.setGeneralUIText(this.characterName, text); // 獲得前メッセージの表示

                yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
                yield return null; // 1フレーム待つ

                this.uiManager.setGeneralUICharacterImage("Mallory", "HAPPY"); // イメージの表示
                text = "ここを…　こうして…";
                this.uiManager.setGeneralUIText(this.characterName, text); // 獲得前メッセージの表示

                yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
                yield return null; // 1フレーム待つ

                this.uiManager.setGeneralUICharacterImage("Mallory", "EXCITED"); // イメージの表示
                text = "……………";
                this.uiManager.setGeneralUIText(this.characterName, text); // 獲得前メッセージの表示

                yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
                yield return null; // 1フレーム待つ

                this.uiManager.generalUISwitchDirect(UI_OFF); // テキスト表示用UIオフ

                this.doorController.openDoor(openFlag); // 真のときdoorを開ける

                this.uiManager.inputRcockSwitch(); // 入力制のオン
                yield return new WaitForSeconds(DELAY_TIME); // 数秒待つ
                yield return null; // 1フレーム待つ 
                this.uiManager.inputRcockSwitch(); // 入力制のオフ
               
            }

            // ドアが開いているかどうかのフラグを獲得 開いていたら真
            this.openDoorFlag = this.doorController.getOpenFlag();
            yield return null; // 1フレーム待つ ドアが開いたかどうかの更新を待つため
            
            if(this.openDoorFlag){ // ドアが開いているとき
                this.uiManager.openDoorText(); // セリフを表示
            }
            else{ // ドアが閉まっているとき
                this.uiManager.closedDoorText(); // セリフを表示
            }


        }

        yield return null; // 1フレーム待つ

    }




    // =================================


    // ==========パスワード獲得イベント==========

    // 獲得前テキストのセット
    private void setBeforeText(string text){
        this.beforeText = text;
    }

    // 獲得前テキストのセット
    private void setAfterText(string text){
        this.afterText = text;
    }

    /*// 獲得前テキストのゲット
    private string getBeforeText(){
        return this.beforeText;
    }

    // 獲得前テキストのゲット
    private string getAfterText(){
        return this.afterText;
    }*/

    // 獲得したいパスワードデータのパスワードIDをセット
    private void setPasswordDataID(string passID){
        this.getPasswordDataID = passID;
    }

    // パスワードを獲得状態にする　＆　獲得したパスワードデータの保持
    private void getPasswordData(string passID){

        this.passwordData = this.passwordManager.getPasswordData(passID); // パスワードデータの獲得
        this.passwordManager.setPasswordDataGetFlag(this.passwordData); // パスワード獲得フラグの更新　真にする

        Debug.Log("A GET : " + this.passwordData.getPassword() + " , " + this.passwordManager.checkPasswordDataGetFlag(passwordData));

    }

    // パスワード獲得時のメッセージ
    private string getPasswordMessage(string initialText, string endText){

        string message = "";
        string password = this.passwordData.getPassword(); // パスワードを獲得

        message = initialText + password + endText;

        return message;
    }

    // パスワード獲得時のメッセージ
    private void passwordGetMessage(){

        string initial = "パスワードっぽい文字列\n「   ";
        string end =     "   」\nを　獲得した";

        string message = this.getPasswordMessage(initial, end); // 表示メッセージの生成と獲得
        this.uiManager.setGeneralUIText(this.characterName, message); // 獲得メッセージの表示

    }

    // パスワード獲得用コルーチン
    private IEnumerator getPasswordDataCoroutine(){

        yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
        yield return null; // 1フレーム待つ

        this.uiManager.generalUISwitchDirect(UI_ON); // テキスト表示用UIオン

        this.uiManager.setGeneralUICharacterImage("Mallory", "EXCLAMATION"); // イメージの表示
        this.uiManager.setGeneralUIText(this.characterName, this.beforeText); // 獲得前メッセージの表示

        yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
        yield return null; // 1フレーム待つ

        if(this.tanakaPcPasswordFlag){ // 田中PCにログインしているとき

            this.getPasswordData(this.getPasswordDataID); // パスワードを獲得状態にする　＆　獲得したパスワードデータの保持
            this.passwordGetMessage();// パスワード獲得時のメッセージ

            yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
            yield return null; // 1フレーム待つ

            this.uiManager.setGeneralUICharacterImage("Mallory", "EXCITED"); // イメージの表示
            this.uiManager.setGeneralUIText(this.characterName, this.afterText); // 獲得後メッセージの表示

        }
        else{ // ログインしていないとき

            this.uiManager.setGeneralUICharacterImage("Mallory", "BLUE"); // イメージの表示
            string text = "そんな事より";
            this.uiManager.setGeneralUIText(this.characterName, text); // 獲得メッセージの表示

            yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
            yield return null; // 1フレーム待つ

            this.uiManager.setGeneralUICharacterImage("Mallory", "BLUE"); // イメージの表示
            text = "早くログインできそうなパソコンを　さがさないと…";
            this.uiManager.setGeneralUIText(this.characterName, text); // 獲得メッセージの表示


        }

        yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
        yield return null; // 1フレーム待つ

        this.uiManager.generalUISwitchDirect(UI_OFF); // テキスト表示用UIオフ

    }

    // ======================================


    // =============クリアイベント==============

    // シーンの切り替え
    private void sceneChanger(string sceneName){

        Debug.Log("Scene : " + sceneName + " をロード");
        SceneManager.LoadSceneAsync(sceneName); // シーンを非同期でロード
    }

    // ゲームをクリアしたかどうか クリアしたときリザルトシーンへ
    private void gameClearChecker(){

        // ドアが開いているかどうか
        bool openExitFlag = this.doorController.getOpenFlag();
        if(openExitFlag){ 

            this.scoreDataManager.timerOff(); // クリア時間の計測を終了する

            Debug.Log("クリア！！！");
            this.sceneChanger(GAME_SCENE_RESULT);

        }

     }

    // 出入り口を調べた時のイベント
    private IEnumerator doorEventCoroutine(){

        this.uiManager.generalUISwitchDirect(UI_ON); // テキスト表示用UIオン


        yield return new WaitUntil( () => Input.GetMouseButtonUp(0) ); // クリックされたとき処理を進める
        yield return null; // 1フレーム待つ

        this.uiManager.generalUISwitchDirect(UI_OFF); // テキスト表示用UIオフ

    }

    // =======================================

}











