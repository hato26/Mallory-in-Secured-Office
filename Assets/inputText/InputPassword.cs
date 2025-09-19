using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TMP_InputField を使うため
using TMPro;

public class InputPassword : MonoBehaviour
{

    // InputFieldを格納
    private TMP_InputField inputPassword;

    // パスワードを格納
    string inputPasswordStr;

    // 入力終了フラグ
    bool textEditEndFlag = false;



    // Start is called before the first frame update
    void Start()
    {

        // InputFieldコンポーネントを獲得
        GameObject temp = GameObject.Find("InputPassword");
        this.inputPassword = temp.GetComponent<TMP_InputField>();
        
    }

    // 入力終了フラグの初期化
    public void initializeTextEditEndFlag(){
        this.textEditEndFlag = false; // 入力終了フラグをFalse
    }

    // 入力可能状態になったら入力フォームを空にする
    public void initializeInputPasswordText(){
        this.inputPassword.text = ""; // 入力フォームを空にする
    }

    // 入力されたパスワードの格納 入力終了フラグをtrueにする
    public void setInputPassword(){

        // 入力されたパスワードを獲得
        this.inputPasswordStr = this.inputPassword.text;
        this.textEditEndFlag = true; // フラグを立てる
        this.initializeInputPasswordText(); // 入力フォームを空にする

    }

    // 格納したパスワードのゲッター関数
    public string getInputPassword(){
        return this.inputPasswordStr;
    }

    // 入力終了フラグのゲッター関数 EditEndの関数が実行されたらtrue
    public bool getTextEditEndFlag(){ Debug.Log("getTextEditEndFlag()");
        return this.textEditEndFlag;
    }




}



