using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditManager : MonoBehaviour
{

    // パネル
    [SerializeField] private GameObject creditPanel;

    // テキスト
    [SerializeField] private TMP_Text creditText;

    // ファイルネーム
    [SerializeField] private string creditFileName;

    // CSV
    private CSVReader csvReader;


    // Start is called before the first frame update
    void Start()
    {

        this.csvReader = gameObject.GetComponent<CSVReader>(); // csvリーダーを獲得
        this.csvReader.setCSVFile(creditFileName); // csvのセット
        //this.csvReader.testCSVReader(); // テスト表示

        this.displayCreditData(); // リストの獲得と表示
        
    }


    // パネルのON
    public void creditPanelON(){
        this.creditPanel.SetActive(true); // パネルをアクティブ
    }

    // パネルのOFF
    public void creditPanelOFF(){
        this.creditPanel.SetActive(false); // パネルを非アクティブ
    }
    
    // リストの獲得と表示
    private void displayCreditData(){

        string creditDataText = "";
        List<string[]> creditDataList = this.csvReader.getCSVDataList(); // リストの獲得

        // 表示するテキストの生成
        for(int i = 1; i < creditDataList.Count; i++ ){

            creditDataText += "\n\n";

            for(int j = 1; j < creditDataList[i].Length; j++ ){
                creditDataText += creditDataList[i][j] + "     ";
            }

            //creditDataText += "\n\n";

        }

        this.creditText.text = creditDataText; // 表示

    }






}




