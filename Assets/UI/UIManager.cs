using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{

    // 台詞データのインデックス(定数)
    private const int NAME_INDEX = 0;
    private const int TEXT_INDEX = 1;

    // UIの ON or OFF (定数)
    private const string UI_ON = "ON";
    private const string UI_OFF = "OFF";

    // 汎用のテキスト表示用UIの獲得
    [SerializeField] private GameObject generalTextPanel;
    private GeneralTextManager generalTextManager; 
    private bool directFlag = false; // 汎用のテキスト表示用UIを直接操作用でオンにした時

    // 探索開始時の台詞の読み込み
    [SerializeField] private string fileName; // CSVファイルの指定

    // パスワード入力時のパネルの獲得
    [SerializeField] private GameObject inputPasswordPanel;

    [SerializeField] private string inputPasswordUITextCSV_01; // パスワード入力UIを表示した時のセリフデータ
    [SerializeField] private string inputPasswordUITextCSV_02; // ログインを失敗した時のセリフデータ
    
    // 入力されたパスワードの獲得
    private InputPassword inputPassword;

    // パスワードクラック時のパネルの獲得
    [SerializeField] private GameObject passwordCrackPanel;
    private PasswordCrackButtonManager passwordCrackButtonManager;
    private PasswordListManager passwordListManager;

    [SerializeField] private string passwordCrackUITextCSV_01; // パスワードクラックUI移行時のセリフデータ
    [SerializeField] private string passwordCrackUITextCSV_openDoor; // ドアが開いた時のセリフデータ
    [SerializeField] private string passwordCrackUITextCSV_closedDoor; // ドアが閉じたままの時のセリフデータ

    // 調べたときに出るテキスト
    [SerializeField] private string tanakaDesk_book; // 田中デスクの本を調べた時のセリフデータ

    // 入力制限用オブジェクト
    [SerializeField] private GameObject inputRcock;


    // Start is called before the first frame update
    void Start()
    {
        // 探索開始時のUI 指定ファイルは　this.fileName
        this.generalUISwitch(UI_ON, this.fileName);
        
    }

    // Update is called once per frame
    void Update()
    {

        // 汎用のテキスト表示用UIによる台詞等の表示 
        if(this.directFlag){ // 直接操作用でUIをオンした時
            // 何もしない
        }
        else{ // 直接操作用でないメソッドでオンした時

            bool endFlag = this.generalTextManager.getControlFlag();
            if(!endFlag){
                this.generalUISwitch(UI_OFF, this.fileName); // 指定したファイルが違ってもUIはOFFになる
            }

        }


    }


    // UIの ON or OFF
    private void uiSwitch(GameObject panel, string input){

        // パネルがアクティブかどうか
        bool activePanelFlag = panel.activeInHierarchy;
        //Debug.Log("uiSwitch:"+panel+" "+activePanelFlag);

        if(activePanelFlag){ // パネルがアクティブなとき
            if(input == UI_OFF){ // OFFのとき
                panel.SetActive(false);// パネルを非アクティブ
            }
        }
        else{ // パネルがアクティブでない時
            if(input == UI_ON){ // ONのとき
                panel.SetActive(true); // パネルをアクティブ  
            }
        }

    }


    //=========汎用テキスト表示のUI=========

    // 汎用テキスト表示のUIの ON or OFF
    private void generalUISwitch(string input, string csvFileName){

        // UIの ON or OFF
        this.uiSwitch(this.generalTextPanel, input);
        

        // UIをONするとき
        if(input == UI_ON){

            // generalTextManagerからコンポーネントを獲得
            //GameObject generalTextManager_obj = GameObject.Find("GeneralTextManager"); なぜかできない
            GameObject generalTextManager_obj = this.generalTextPanel.transform.GetChild(0).gameObject;
            this.generalTextManager = generalTextManager_obj.GetComponent<GeneralTextManager>();


            // 読み込むCSVファイル（台詞）を設定
            this.generalTextManager.setCSVFile(csvFileName);

        }
        else{ // OFFするとき
            // 何もしない
        }

    }

    // 汎用テキスト表示のUIの ON or OFF (直接操作用)
    public void generalUISwitchDirect(string input){

        // UIの ON or OFF
        this.uiSwitch(this.generalTextPanel, input);

        // UIをONするとき
        if(input == UI_ON){

            // generalTextManagerからコンポーネントを獲得
            //GameObject generalTextManager_obj = GameObject.Find("GeneralTextManager"); なぜかできない
            GameObject generalTextManager_obj = this.generalTextPanel.transform.GetChild(0).gameObject;
            this.generalTextManager = generalTextManager_obj.GetComponent<GeneralTextManager>();

            this.directFlag = true; // フラグの更新　true

            this.deleteGeneralUIText(); // テキストを直接削除

        }
        else{ // OFFするとき

            this.directFlag = false; // フラグの更新　false
            this.deleteGeneralUIText(); // テキストを直接削除

        }

    }

    // テキストを直接表示
    public void setGeneralUIText(string name, string text){
        this.generalTextManager.setGeneralUIText(name, text);
    }

    // テキストを直接削除
    public void deleteGeneralUIText(){
        this.generalTextManager.deleteGeneralUIText(); // テキストを削除
    }

    // テキストの表示が終わったかどうかのフラグ　表示が終わったらfalse
    public bool getGeneralUITextEndFlag(){

        bool endFlag = this.generalTextManager.getControlFlag();

        return endFlag;
    }

    // キャラクターイメージを直接表示
    public void setGeneralUICharacterImage(string characteName, string emotions){
        this.generalTextManager.setGeneralUIImage(characteName, emotions);

    }

    //==============================



    //=========パスワード入力時のUI=========

    // パスワード入力用UIの ON or OFF
    public void inputPasswordUISwitch(string input){

        // UIの ON or OFF
        this.uiSwitch(this.inputPasswordPanel, input);

        // UIをONするとき
        if(input == UI_ON){

            // 入力されたパスワードの読み取り
            // インプットパスワードマネージャーから入力されたパスワードを読み取る
            GameObject inputPasswordManager = this.inputPasswordPanel.transform.GetChild(0).gameObject;
            this.inputPassword = inputPasswordManager.GetComponent<InputPassword>();

            this.generalUISwitch(UI_ON, this.inputPasswordUITextCSV_01); // 汎用テキスト表示用UIにthis.InputPasswordUITextCSV_01を表示

        }
        else{ // OFFするとき

            this.inputPassword.initializeTextEditEndFlag(); // 入力終了フラグの初期化
            //this.generalUISwitch(UI_ON, this.passwordCrackUITextCSV_01); // 汎用テキスト表示用UIにthis.passwordCrackUITextCSV_01を表示
        
        }

    }

    // 田中デスクの本を調べた時のセリフ
    public void tanakaDeskBookText(){
        this.generalUISwitch(UI_ON, this.tanakaDesk_book); // 汎用テキスト表示用UIにthis.InputPasswordUITextCSV_02を表示
    }

    // 入力パスワードが正しいときの台詞を表示
    public void correctPasswordText(){
        this.generalUISwitch(UI_ON, this.passwordCrackUITextCSV_01); // 汎用テキスト表示用UIにthis.passwordCrackUITextCSV_01を表示
    }

    // 入力パスワードが正しくないときの台詞を表示correct
    public void lncorrectPasswordText(){
        this.generalUISwitch(UI_ON, this.inputPasswordUITextCSV_02); // 汎用テキスト表示用UIにthis.InputPasswordUITextCSV_02を表示
    }

    // 入力されたパスワードの獲得
    public string getInputPassword(){

        // 入力されたパスワードの獲得
        string inputPassword = this.inputPassword.getInputPassword();

        return inputPassword;
    }

    // 入力終了したかどうか
    public bool getInputEndFlag(){

        // 入力されたパスワードの獲得
        bool inputEndFlag = this.inputPassword.getTextEditEndFlag();

        return inputEndFlag;
    }


    //===================================



    //=========パスワードリスト攻撃時のUI=========

    // パスワードクラックUIの ON or OFF
    public void passwordCrackUISwitch(string input){

        // UIの ON or OFF
        this.uiSwitch(this.passwordCrackPanel, input);
        

        // UIをONするとき
        if(input == UI_ON){
 
            // パスワードクラックボタンのコントロール
            GameObject passwordCrackManager = GameObject.Find("PasswordCrackManager");
            this.passwordCrackButtonManager = passwordCrackManager.GetComponent<PasswordCrackButtonManager>();

            // パスワードリストの表示
            GameObject passwordListManager_obj = GameObject.Find("PasswordListManager");
            this.passwordListManager = passwordListManager_obj.GetComponent<PasswordListManager>();
 
        }
        else{ // OFFするとき

        }

    }

    // パスワードクラックボタンの入力獲得
    public bool getAttackFlag(){

        bool attackFlag = false;
        
        // 一度でもパスワードリストを作らないと(表示させないと)ボタンを押しても反応しないようにする
        bool createFlag = this.getCreateListFlag();
        if(createFlag){
        
            attackFlag = this.passwordCrackButtonManager.getPasswordCrackFlag(); // パスワードクラックボタンの入力獲得
            this.passwordCrackButtonManager.initializePasswordCrackFlag(); // 入力の初期化
        
        }
        else{
            this.passwordCrackButtonManager.initializePasswordCrackFlag(); // 入力の初期化
        }

        return attackFlag;
    }

    // パスワードクラックボタンの有効、無効の切り替え
    public void passwordCrackButtonSwitch(string input){

        GameObject passwordCrackButton = this.passwordCrackButtonManager.getPasswordCrackButton(); // ボタンの獲得
        this.uiSwitch(passwordCrackButton, input); // UIのONとOFF

    }

    // パスワードリストを作ったかどうか
    public bool getCreateListFlag(){
        return this.passwordListManager.getCreateFlag(); // リストを作ったかどうか
    }

    // パスワードリストを作っていない状態にする
    public void restCreateFlag(){
        this.passwordListManager.resetCreateFlag(); // パスワードリストを作っていない状態にする
    }

    // ドアが開いた時のセリフ
    public void openDoorText(){
        this.generalUISwitch(UI_ON, this.passwordCrackUITextCSV_openDoor); // 汎用テキスト表示用UIにthis.passwordCrackUITextCSV_01を表示
    }

    // ドアが閉じたままの時のセリフ
    public void closedDoorText(){
        this.generalUISwitch(UI_ON, this.passwordCrackUITextCSV_closedDoor); // 汎用テキスト表示用UIにthis.passwordCrackUITextCSV_01を表示
    }


    //========================================


    //=========入力制限用オブジェクト=========

    // 入力制限の　ON　と OFF
    public void inputRcockSwitch(){

        bool activeFlag = this.inputRcock.activeInHierarchy;
        this.inputRcock.SetActive(!activeFlag); // オブジェクトが　アクティブなとき非アクティブ　非アクティブなときアクティブ

    }

    //====================================

}





