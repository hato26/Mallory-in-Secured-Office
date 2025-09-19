using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PasswordData" ,menuName = "PasswordData")]
public class PasswordData : ScriptableObject
{

    //
    public enum PasswordType{
        Server, PC, Book, Binder, Memo
    }

    // パスワードID
    [SerializeField]
    private string passwordID;

    // パスワードのタイプ(隠している場所)
    [SerializeField]
    private PasswordType hide;

    // パスワード
    [SerializeField]
    private string password;


    // ゲッター関数
    public string getPasswordID(){
        return passwordID;
    }

    public PasswordType getPasswordType(){
        return hide;
    }

    public string getPassword(){
        return password;
    }



}








