using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputButtonManager : MonoBehaviour
{

    // 定数
    // タイトルシーン名
    const string GAME_SCENE_TITLE = "TitleScene";

    // メインゲームシーン名
    const string GAME_SCENE_MAIN = "GameScenesMain";

    // 変数
    // エピローグスタートボタンのフラグ
    private bool startPrologueButtonFlag = false;

    // ゲームスタートボタンのフラグ
    private bool startMainGameButtonFlag = false;

    // クレシット表示ボタンのフラグ
    private bool creditButtonFlag = false;

    // エピローグスタートのリスタートボタンのフラグ
    private bool restartPrologueButtonFlag = false;

    // ゲームスタートのリスタートボタンのフラグ
    private bool restartMainGameButtonFlag = false;

    // クレシット表示ボタンのフラグ
    private bool goTitleButtonFlag = false;

    // クレジットの管理
    CreditManager creditManager = null;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.processChanger(); // 入力したボタンによって処理を変える
        this.creditPanelOFF(); // クリックでクレジットを非表示
    }


    // シーンの切り替え
    private void sceneChanger(string sceneName){

        Debug.Log("Scene : " + sceneName + " をロード");
        SceneManager.LoadSceneAsync(sceneName); // シーンを非同期でロード
    }

    // クレジットUIの表示
    private void creditPanelON(){

        GameObject creditManager_obj = GameObject.Find("CreditManager");
        this.creditManager = creditManager_obj.GetComponent<CreditManager>();

        if(this.creditManager != null){ // ヌルでない時
            this.creditManager.creditPanelON(); // UIをON
        }

    }

    // クレジットUIの非表示とフラグリセット(クリックしたら)
    private void creditPanelOFF(){

        bool clickUP = Input.GetMouseButtonDown(0); // クリックしたかどうか

        if(this.creditManager != null && clickUP){ // ヌルでない時 & クリックした時
            this.creditManager.creditPanelOFF(); // UIをOFF
            this.creditButtonFlag = false; // フラグのリセット
        }

    }

    // 入力したボタンによって処理を変える
    private void processChanger(){

        if(this.startPrologueButtonFlag){ // エピローグスタートボタンを押した時
            //+++++++++++++++
        }
        else if(this.startMainGameButtonFlag){ // ゲームスタートボタンを押した時
            this.sceneChanger(GAME_SCENE_MAIN); // ゲームシーンメインへ遷移
        }
        else if(this.restartPrologueButtonFlag){ // エピローグからボタンを押した時
            //+++++++++++++++
        }
        else if(this.restartMainGameButtonFlag){ // もう一回ボタンを押した時
            this.sceneChanger(GAME_SCENE_MAIN); // ゲームシーンメインへ遷移
        }
        else if(this.goTitleButtonFlag){ // もう一回ボタンを押した時
            this.sceneChanger(GAME_SCENE_TITLE); // タイトルへ遷移
        }
        else if(this.creditButtonFlag){ // クレジット表示ボタンを押した時
            this.creditPanelON(); // クレジットの表示
        }


    }


    // エピローグスタートボタンの入力獲得
    public void setInputStartPrologueButton(){
        this.startPrologueButtonFlag = true;
    }

    // ゲームスタートボタンの入力獲得
    public void setInputStartMainGameButto(){
        this.startMainGameButtonFlag = true;
    }

    // エピローグリスタートボタンの入力獲得
    public void setInputRestartPrologueButton(){
        this.restartPrologueButtonFlag = true;
    }

    // ゲームリスタートボタンの入力獲得
    public void setInputRestartMainGameButto(){
        this.restartMainGameButtonFlag = true;
    }

    // クレジット表示ボタンの入力獲得
    public void setInputStartCreditButtonFlag(){
        this.creditButtonFlag = true;
    }

    // クレジット表示ボタンの入力獲得
    public void setInputGoTitleButtonFlag(){
        this.goTitleButtonFlag = true;
    }

}
