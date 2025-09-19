using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData" ,menuName = "ScoreData")]
public class ScoreData : ScriptableObject
{


    [SerializeField] private float initStartTime;                      // クリアタイムの初期値
    private float startTime;                                           // 計測開始時間

    [SerializeField] private float initEndTime;                        // クリアタイムの初期値
    private float endTime;                                             // 計測終了時間

    bool timerOnFlag = false;                                          // タイマーが　ON > true
    bool timerOffFlag = false;                                         // OFF > false



    [SerializeField] private int initNumberOfAttacksOnTanakaPC;        // 田中PCへの攻撃回数の初期値
    private int numberOfAttacksOnTanakaPC;                             // 田中PCへの攻撃回数


    [SerializeField] private int initNumberOfPasswordListbasedAttack;  // パスワードリスト攻撃の回数の初期値
    private int numberOfPasswordListbasedAttack;                       // パスワードリスト攻撃の回数



    // スコアの初期化
    public void initializeScoredata(){

        this.startTime = this.initStartTime;                                              // 計測開始時間
        this.endTime = this.initEndTime;                                                  // 計測終了時間
        this.timerOnFlag = false;                                                         // タイマーフラグ on
        this.timerOffFlag = false;                                                        // タイマーフラグ off
        this.numberOfAttacksOnTanakaPC = this.initNumberOfAttacksOnTanakaPC;              // 田中PCへの攻撃回数
        this.numberOfPasswordListbasedAttack = this.initNumberOfPasswordListbasedAttack;  // パスワードリスト攻撃の回数

    }

    // 計測開始
    public void timerOn(){

        if(!this.timerOnFlag){ // falseのとき

            this.startTime = Time.time; Debug.Log("timerOn : " + this.startTime);
            this.timerOnFlag = true;

        }
    
    }

    // 計測終了
    public void timerOff(){

        if(!this.timerOffFlag){ // falseのとき

            this.endTime = Time.time; Debug.Log("timerOff : " + this.endTime);
            this.timerOffFlag = true;

        }

    }

    // 田中PCへの攻撃回数の加算
    public void incrementNumberOfAttacksOnTanakaPC(){
        this.numberOfAttacksOnTanakaPC++; Debug.Log("at taPC : " + this.numberOfAttacksOnTanakaPC);
    }

    // パスワードリスト攻撃の回数の加算
    public void incrementNumberOfPasswordListbasedAttack(){
        this.numberOfPasswordListbasedAttack++; Debug.Log("at lsit : " + this.numberOfPasswordListbasedAttack);
    }


    // ========== ゲッター関数 ==========

    // 計測開始時間
    public float getStartTime(){
        return this.startTime;
    }

    // 計測終了時間
    public float getEndTime(){
        return this.endTime;
    }

    // 田中PCへの攻撃回数
    public int getNumberOfAttacksOnTanakaPC(){
        return this.numberOfAttacksOnTanakaPC;
    }

    // パスワードリスト攻撃の回数
    public int getNumberOfPasswordListbasedAttack(){
        return this.numberOfPasswordListbasedAttack;
    }


    // ================================


}
