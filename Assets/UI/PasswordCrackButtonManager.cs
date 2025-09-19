using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PasswordCrackButtonManager : MonoBehaviour
{

    // PasswordCrackButtonの獲得
    [SerializeField] GameObject passwordCrackButton;

    // PasswordCrackButtonからの入力を保持
    private bool passwordCrackFlag = false;

    // PasswordCrackButtonの獲得
    public GameObject getPasswordCrackButton(){
        return this.passwordCrackButton;
    }

    // PasswordCrackButtonからの入力を獲得
    public void setPasswordCrackFlag(){
        this.passwordCrackFlag = true;
    }

    // PasswordCrackButtonからの入力を初期化
    public void initializePasswordCrackFlag(){
        this.passwordCrackFlag = false;
    }

    public bool getPasswordCrackFlag(){
        return this.passwordCrackFlag;
    }



}
