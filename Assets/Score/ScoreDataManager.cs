using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Rendering;
using UnityEngine;
//using UnityEngine.Video;

public class ScoreDataManager : MonoBehaviour
{

    // スコアデータ一覧のキー　(定数)
    public const string SCORE_DATA_KEY_TIME = "Time"; // クリアタイム
    public const string SCORE_DATA_KEY_TANAKA = "Tanaka"; 
    public const string SCORE_DATA_KEY_LIST = "List";

    // スコアデータ
    [SerializeField] private ScoreData scoreData;



    // Start is called before the first frame update
    void Start()
    {
        this.timerOn(); // クリアタイムの計測開始
    }

    // スコアデータの初期化
    public void initializeScoredata(){
        this.scoreData.initializeScoredata();
    }

    // クリアタイムの計測を開始する
    public void timerOn(){
            this.scoreData.timerOn(); // クリアタイムの計測開始
    }

    // クリアタイムの計測を終了する
    public void timerOff(){
            this.scoreData.timerOff(); // クリアタイムの計測終了
    }
    
    // クリアタイムの計算
    public float getClearTime(){

        float startTime = this.scoreData.getStartTime(); // 計測開始時間を獲得
        float endTime = this.scoreData.getEndTime(); // 計測終了時間を獲得
        Debug.Log("st : " + startTime + " , en : " + endTime);
        float clearTime = endTime - startTime; // 計測開始時間と計測終了時間の差を計算

        return clearTime;
    }

    // 田中PCに対する攻撃の試行回数
    public void incrementNumberOfAttacksOnTanakaPC(){
        this.scoreData.incrementNumberOfAttacksOnTanakaPC(); // 攻撃回数を１増やす
    }

    // 田中PCに対する攻撃の試行回数の獲得
    public int getNumberOfAttacksOnTanakaPC(){
        return this.scoreData.getNumberOfAttacksOnTanakaPC();
    }

    // パスワードリスト攻撃の試行回数
    public void incrementNumberOfPasswordListbasedAttack(){
        this.scoreData.incrementNumberOfPasswordListbasedAttack(); // 攻撃回数を１増やす
    }

    // パスワードリスト攻撃の試行回数の獲得
    public int getNumberOfPasswordListbasedAttack(){
        return this.scoreData.getNumberOfPasswordListbasedAttack();
    }

    // スコアデータ一覧の獲得
    public Dictionary<string, string> getScoreDataDictionary(){

        const int HOUR = 3600;
        const int MINUTES = 60;

        const string D_2 = "D2";
        const string COLON = ":";

        Dictionary<string, string> scoreDataDictionary = new Dictionary<string, string>();

        // スコアの獲得
        float clearTime = this.getClearTime(); // クリアタイム
        int numberOfAttacksOnTanakaPC = this.getNumberOfAttacksOnTanakaPC(); // 田中PCに対する攻撃の試行回数
        int numberOfPasswordListbasedAttac = this.getNumberOfPasswordListbasedAttack(); // パスワードリスト攻撃の試行回数

        // クリアタイムを hh:mm:ss に変換
        int clearTimeTemp = (int)clearTime;

        int clearTime_hh = clearTimeTemp / HOUR; // hh
        clearTimeTemp = clearTimeTemp % HOUR;

        int clearTime_mm = clearTimeTemp / MINUTES; // mm
        clearTimeTemp = clearTimeTemp % MINUTES;

        int clearTime_ss = clearTimeTemp; // ss

        Debug.Log("hh : " + clearTime_hh);
        Debug.Log("mm : " + clearTime_mm);
        Debug.Log("ss : " + clearTime_ss);

        string clearTimeString = clearTime_hh.ToString(D_2) + COLON + clearTime_mm.ToString(D_2) + COLON + clearTime_ss.ToString(D_2); // hh:mm:ss
        Debug.Log("hh:mm:ss , " + clearTimeString);

        // スコアを文字列型で格納
        scoreDataDictionary.Add(SCORE_DATA_KEY_TIME, clearTimeString );
        scoreDataDictionary.Add(SCORE_DATA_KEY_TANAKA, numberOfAttacksOnTanakaPC.ToString() );
        scoreDataDictionary.Add(SCORE_DATA_KEY_LIST, numberOfPasswordListbasedAttac.ToString() );

        return scoreDataDictionary;
    }



}




