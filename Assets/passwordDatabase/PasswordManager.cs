using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{

    // パスワードデータベース
    [SerializeField]
    private PasswordDatabase passwordDatabase;

    // パスワード獲得管理
    private Dictionary<PasswordData, bool> passwordFlag = new Dictionary<PasswordData, bool>();


    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < this.passwordDatabase.getPasswordLists().Count; i++ ){
                this.passwordFlag.Add(this.passwordDatabase.getPasswordLists()[i], false);
        }
        
        for(int i = 0; i < this.passwordDatabase.getPasswordLists().Count; i++ ){

            string passId = this.passwordDatabase.getPasswordLists()[i].getPasswordID();
            PasswordData pass = this.getPasswordData(passId);
            Debug.Log(pass.getPasswordID() + " : " + pass.getPassword() + " : " + this.passwordFlag[pass]);

        }

    }


    // passIDに対応するパスワードデータを返す
    public PasswordData getPasswordData(string passID){
        
        PasswordData lez = this.passwordDatabase.getPasswordLists().Find(passwordId => passwordId.getPasswordID() == passID);

        return lez;

    }

    // パスワードを獲得状態にする
    public void setPasswordDataGetFlag(PasswordData passwordData){

        // パスワードフラグがfalseのとき
        if(!this.passwordFlag[passwordData]){
            this.passwordFlag[passwordData] = true;
        }

    }

    // 指定されたパスワードが獲得状態かどうか 獲得状態のときtrue
    public bool checkPasswordDataGetFlag(PasswordData passwordData){

        bool passFlag = this.passwordFlag[passwordData];

        return passFlag;
    }

    // 獲得パスワードの総数を返す
    public int getPasswordGetSum(){

        int sum = 0;

        // 獲得パスワードのカウント
        for(int i = 0; i < this.passwordDatabase.getPasswordLists().Count; i++ ){

            PasswordData passwordData = this.passwordDatabase.getPasswordLists()[i];
            if(this.passwordFlag[passwordData]){ // パスワードフラグがtrueのとき
                sum++;
            }
            
        }

        return sum;
    }

    // 獲得状態のスワードの一覧を返す
    public string[] getPasswordGetArray(){

        int passCount = this.getPasswordGetSum();
        int getArrayIndex = 0;
        string[] getArray = new string[passCount]; // 獲得パスワード分のサイズの配列を作成


        for(int i = 0; i < this.passwordDatabase.getPasswordLists().Count; i++ ){

            PasswordData passwordData = this.passwordDatabase.getPasswordLists()[i];
            if(this.passwordFlag[passwordData]){ // パスワードフラグがtrueのとき

                getArray[getArrayIndex] = passwordData.getPassword(); // パスワードを格納
                getArrayIndex ++;
            }

        }

        return getArray;
    }

}
