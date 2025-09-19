using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{

    // animation
    private Animator doorAnimator;
    private bool openFlag = false;

     // Doorが一度でも開いたか
    private bool openDoorFlag = false;

    // ドアのパスワードデータの保持
    private PasswordData doorPasswordData;


    // Start is called before the first frame update
    void Start()
    {
        this.doorAnimator = GetComponent<Animator>(); // testerのアニメーターを獲得

    }

    // Update is called once per frame
    void Update()
    {
        // this.openFlagが真だと実行
        bool flag = this.openFlag;
        if(flag){

            this.doorAnimator.SetBool("openFlag", flag);
            this.openFlag = false;

        }

    }

    // ドアのパスワードデータをセットする
    public void setDoorPasswordData(PasswordData doorPass){
        this.doorPasswordData = doorPass;
    }

    // パスワードの照会
    public bool passwordChecker(string[] passwod){

        bool flag = false;
        string correctPassword = this.doorPasswordData.getPassword(); // Doorのパスワードデータからパスワードを獲得

        Debug.Log("Door : " + correctPassword);

        // Doorのパスワードと入力されたパスワードが同じとき真
        for(int i = 0; i < passwod.Length; i++ ){

            if(correctPassword == passwod[i]){
                flag = true;
            }

        }

        return flag;
    }

    // 出口を開く　パスワードが正しいときopenFlagをtrueにする
    public void openDoor(bool checkFlag){

        // パスワードが正しいかどうかの確認 真のとき正しいとする
        if(checkFlag){// 正しいときopenFlagをtrue

            this.openFlag = true;
            this.openDoorFlag = true; // ドアが開いているかフラグの更新

        }
    
    }

    // openFlagの獲得 開いているとき真
    public bool getOpenFlag(){
        return this.openDoorFlag;
    }

}





