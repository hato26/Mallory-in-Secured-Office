using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 田中のデスクに関するクラス
public class TanakaDesk : MonoBehaviour
{

    // パスワードマネージャー
    private GameObject passwordManager_obj;
    private PasswordManager passwordManager;

    // 田中のパスワードデータ
    private PasswordData tanakaPasswordData;

    // 田中のパスワードID
    private string tanakaPcPasswordID = "PASS_TANAKA";

    // 田中のパスワード
    //private string tanakaPcPassword;

    // 本を調べたかどうか
    private bool searchBookFlag = false;

    // 田中のデスクの本を調べた時のメッセージ
    private string searchBookMessage = "本と本の間から \"田中\" と書かれた社員証が 出てきた。\nここは 田中さんの デスクのようだ。";

    // サーチ済みのメッセージ
    private string searchedMessage = "ここはすでに 調べたところだ";



    // コンストラクタ
    public TanakaDesk(){

        // パスワードマネージャーから田中のパスワードデータを獲得
        this.passwordManager_obj = GameObject.Find("PasswordManager");
        this.passwordManager = this.passwordManager_obj.GetComponent<PasswordManager>();
        this.tanakaPasswordData = this.passwordManager.getPasswordData(tanakaPcPasswordID);

    }

    // パスワードの照会
    public bool passwordChecker(string passwodStr){

        bool flag = false;
        string password = this.tanakaPasswordData.getPassword(); // 田中のパスワードデータからパスワードを獲得

        Debug.Log("TANAKA : " + password + " : " + passwodStr);

        // 田中のパスワードと入力されたパスワードが同じとき真
        if(password == passwodStr){
            flag = true;
        }

        return flag;
    }


    // 田中のデスクの本を調べた時のメッセージ　PCのパスワードのヒントとなる
    public string getSearchBookMessage(){

        string message = "";
        
        // 一度でも調べるとサーチ済みのメッセージを代入
        if(this.searchBookFlag){ // サーチ済み
            message = searchedMessage;
        }
        else{ // 未サーチ

            message = searchBookMessage;
            this.searchBookFlag = true;

        }

        return message;
    }

    // 田中のパスワードを返す
    public string getPassword(){

        string password = this.tanakaPasswordData.getPassword();

        return password;
    }






}






