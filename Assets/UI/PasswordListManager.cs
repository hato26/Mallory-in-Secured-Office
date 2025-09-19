using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PasswordListManager : MonoBehaviour
{

    // CreateListButtonからの入力を保持
    private bool createListFlag = false;

    // 一度でもリストを作成しているか
    private bool createFlag = false;

    // パスワードの表示
    private TMP_Text displayPasswordText;

    // パスワードマネージャーの獲得
    private PasswordManager passwordManager;


    // Start is called before the first frame update
    void Start()
    {

        // TMP_Textコンポーネントを獲得
        GameObject displayPasswordText_obj = GameObject.Find("DisplayPasswordText");
        this.displayPasswordText = displayPasswordText_obj.GetComponent<TMP_Text>();

        // パスワードマネージャーの獲得
        GameObject passwordManager_obj = GameObject.Find("PasswordManager");
        this.passwordManager = passwordManager_obj.GetComponent<PasswordManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // trueのときパスワードリストを表示
        if(this.createListFlag){

            this.setDisplayPasswordList();
            this.initializeCreateListFlag();

        }
        else{}

    }


    // CreateListButtonからの入力を獲得
    public void setCreateListFlag(){
        this.createListFlag = true;
    }

    // CreateListButtonからの入力を初期化
    private void initializeCreateListFlag(){
        this.createListFlag = false;
    }

    // this.createListFlagの状態を返す
    public bool getCreateFlag(){
       return this.createFlag;
    }

    // this.createListFlagの状態を戻す
    public void resetCreateFlag(){
        this.createFlag = false;
    }

    // パスワードリストの表示
    private void setDisplayPasswordList(){

        // 獲得パスワード一覧
        string[] getPasswordArray = this.passwordManager.getPasswordGetArray();

        // 表示用文字列の作成
        string displayText = "Password List\n";
        for(int i = 0; i < getPasswordArray.Length; i++ ){
            displayText = displayText + "  > " + getPasswordArray[i] + "\n";
        }
        displayText = displayText + "End";

        // 文字列を表示
        this.displayPasswordText.SetText(displayText);

        // リストを作成しているか
        if(!this.createFlag){ 
            this.createFlag = true;
        }

    }


}
