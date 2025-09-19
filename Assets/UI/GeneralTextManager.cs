using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneralTextManager : MonoBehaviour
{

    // 台詞データのインデックス(定数)
    private const int NAME_INDEX = 0;
    private const int TEXT_INDEX = 1;
    private const int IMAGE_NAME_INDEX = 2;
    private const int EMOTION_INDEX = 3;
    private const int INIT_QUOTE_INDEX = 1;

    // 画像の表示
    private Image generalImage;

    // キャラクターイメージの獲得
    private CharacterImageManager characterImageManager;

    // 表示テキストの初期化
    private const string INIT_UI_TEXT = "";

    // テキストの表示操作
    private TMP_Text generalName = null; // ネームタグ
    private TMP_Text generalText = null; // テキスト表示
    private bool controlFlag = true; // テキストの表示

    // CSVファイルの読み込み
    private CSVReader csvReader;
    private bool loadCSVFileFlag = false; // CSVファイルを読み込んだかどうか
    private int quoteIndex = INIT_QUOTE_INDEX; // 台詞インデックス
    private int initializeIndex = 1; // 初期化用台詞番号

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        // 何かしらのCSVを読み込んでいるとき
        if(this.loadCSVFileFlag){   
             
            // 表示テキストの更新
            if(this.controlFlag){
                this.controlFlag = this.controlGeneralUI(); // UIの操作
            }
            else{
                this.loadCSVFileFlag = false; // this.loadCSVFileFlagの初期化
            }

        }

    }

    // CSVファイルの読み込み
    public void setCSVFile(string fileName){

        // CSVReaderをアタッチ　＆　インスタンスを獲得 (すでにアタッチされてない時実行)
        CSVReader csvReaderTemp = this.gameObject.GetComponent<CSVReader>();
        if(csvReaderTemp == null){

            this.gameObject.AddComponent<CSVReader>();
            this.csvReader = this.gameObject.GetComponent<CSVReader>();

        }

        this.csvReader.setCSVFile(fileName); // CSVファイルの読み込み
        this.quoteIndex = INIT_QUOTE_INDEX; // インデックスの初期化
        this.loadCSVFileFlag = true; // 読み込みフラグを立てる
        this.controlFlag = true; // 表示終了フラグをtrueに

        this.initializeGeneralUI(); // 最初に表示するテキストを設定

    }

    // コンポーネントの獲得
    private void getComponent(){

        // this.generalName this.generalText this.generalImage どれかがnullのとき
        if( (this.generalName == null) || (this.generalText == null) ){
    
            // generalNameのTMP_Textコンポーネントを獲得
            GameObject generalName_obj = GameObject.Find("GeneralName");
            this.generalName = generalName_obj.GetComponent<TMP_Text>();

            // generalTextのTMP_Textコンポーネントを獲得
            GameObject generalText_obj = GameObject.Find("GeneralText");
            this.generalText = generalText_obj.GetComponent<TMP_Text>();

            // CharacterImageManagerコンポーネントの獲得
            GameObject characterImageManager_obj = GameObject.Find("CharacterImageManager");
            this.characterImageManager = characterImageManager_obj.GetComponent<CharacterImageManager>();

            // Imageコンポーネントの獲得
            GameObject generalCharacterImage_obj = GameObject.Find("GeneralCharacterImage");
            this.generalImage = generalCharacterImage_obj.GetComponent<Image>();
    
        }

    }

    // 最初に表示するテキストの設定とセットアップ
    private void initializeGeneralUI(){

        this.getComponent(); // コンポーネントの獲得

        // 台詞データの獲得
        string[] quoteData = this.csvReader.getCSVData(this.initializeIndex);
        this.setGeneralUI(quoteData[NAME_INDEX], quoteData[TEXT_INDEX]);
        this.displayCharacterImage(quoteData[IMAGE_NAME_INDEX], quoteData[EMOTION_INDEX]); // イメージの表示

        this.quoteIndex++;// 台詞番号を更新

    }


    // テキストの表示
    private void setGeneralUI(string name, string text){

        this.generalName.text = name; // キャラクター名
        this.generalText.text = text; // 台詞

    }

    // UIの操作 台詞がnullでないとき　真
    private bool controlGeneralUI(){

        bool flag = true;

        if(Input.GetMouseButtonUp(0)){ // クリックされると処理を行う

            // 台詞データの獲得
            string[] quoteData = this.csvReader.getCSVData(this.quoteIndex);

            // 台詞を表示 (quoteDataがnull以外のとき)
            if(quoteData != null){

                this.setGeneralUI(quoteData[NAME_INDEX], quoteData[TEXT_INDEX]);
                this.displayCharacterImage(quoteData[IMAGE_NAME_INDEX], quoteData[EMOTION_INDEX]); // イメージの表示

            }
            else{ // quoteDataがnullのとき
                flag = false;
            }

            this.quoteIndex++; // 台詞番号を更新

        }

        return flag;
    }

    // 受け取ったテキストをUIに表示
    public void setGeneralUIText(string name, string text){
        this.setGeneralUI(name, text); // テキストを表示
    }

    // UIに表示されたテキストを削除
    public void deleteGeneralUIText(){
        this.setGeneralUI(INIT_UI_TEXT, INIT_UI_TEXT); // テキストを削除
    }

    // 表示が終わったかどうか　表示が終わったらfalse
    public bool getControlFlag(){
        return this.controlFlag;
    }



   // イメージの表示
    private void displayImage(Sprite image){
        this.generalImage.sprite = image;
    }

    // キャラクターのイメージデータの獲得 キャラクター名と感情をいれる
    private Sprite getCharacterImage(string characteName, string emotions){

        // 入力したキャラクター名と感情に応じたイメージを獲得
        Dictionary<string, Sprite> characterImages = this.characterImageManager.getCharacteImagesDictionary(characteName);
        Sprite image = characterImages[emotions];

        return image;
    }

    // キャラクターのイメージを表示　キャラクター名と感情をいれる
    private void displayCharacterImage(string characteName, string emotions){

        // キャラクターのイメージデータの獲得
        Sprite charImage = this.getCharacterImage(characteName, emotions);
        this.displayImage(charImage); // イメージの表示

    }

    // キャラクターのイメージを表示　キャラクター名と感情をいれる
    public void setGeneralUIImage(string characteName, string emotions){
        this.displayCharacterImage(characteName, emotions);
    }



}









