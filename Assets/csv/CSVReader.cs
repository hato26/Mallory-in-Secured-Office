using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class CSVReader : MonoBehaviour
{

    // CSVファイル
    //private TextAsset csvFile;

    // CSVファイルのデータを入れるリスト
    private List<string[]> csvDataList = new List<string[]>();

    // テスト用
    public void testCSVReader(){

        for(int i = 0; i < this.csvDataList.Count; i++){
            Debug.Log(this.csvDataList[i][0] + " : " + this.csvDataList[i][1]);
        }

    }

    // CSVファイルの読み取り
    public void setCSVFile(string fileName){

        // CSVファイルの読み取り
        TextAsset csvFile = Resources.Load(fileName) as TextAsset;
        StringReader strReader = new StringReader(csvFile.text); // StringReaderに変換

        // セリフリストの作成
        List<string[]> csvDataListTemp = new List<string[]>();
        while(strReader.Peek() != -1){

            string line = strReader.ReadLine();    // 1行ずつ読み込む
            string[] lineSplit = line.Split(',');  // ','で区切る
            csvDataListTemp.Add(lineSplit);       // リストに追加

        }
        this.csvDataList = csvDataListTemp;

    }

    // リストの獲得
    public List<string[]> getCSVDataList(){
        return csvDataList;
    }

    // ラベルの獲得
    public string[] getCSVDataLabels(){
        string[] labels = this.csvDataList[0];
        return labels;
    }

    // 横列の獲得
    public string[] getCSVData(int dataNum){

        string[] data = null;

        // リストの範囲内のみ、読み取り
        if(dataNum > 0 && dataNum < this.csvDataList.Count){
            data = this.csvDataList[dataNum];
        }

        return data;
    }





}












