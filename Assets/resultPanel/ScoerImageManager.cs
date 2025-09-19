using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoerImageManager : MonoBehaviour
{

    // キャラクターイメージの獲得
    [SerializeField] private GameObject characterImageManager_obj;
    private CharacterImageManager characterImageManager;

    // キャラクター表示用イメージ
    [SerializeField] private Image characterImage;

    // スコアの獲得
    [SerializeField] private ScoreDataManager scoreDataManager;

    // スコア表示用テキスト
    [SerializeField] private TMP_Text scoreText;

    


    // Start is called before the first frame update
    void Start()
    {

        // コンポーネントの獲得
        this.characterImageManager = this.characterImageManager_obj.GetComponent<CharacterImageManager>();

        this.displayCharacterImage(CharacterImageManager.CHARACTER_NAME_MALLORY, CharacterImageManager.EMOTIONS_EXCLAMATION); // マロリーのびっくりマークイメージの表示

        Dictionary<string, string> scores = this.getScoreData(); // スコアの獲得
        this.displayScoreText(scores); // スコアの表示
        this.scoreDataManager.initializeScoredata(); // スコアデータの初期化
        
    }


    // イメージの表示
    private void displayImage(Sprite image){
        this.characterImage.sprite = image;
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



    // テスト用テキスト
    private string getTestText(){
        return "おめでとう";
    }

    // スコア一覧の獲得
    private Dictionary<string, string> getScoreData(){
        Debug.Log("==========rivate Dictionary<string, string> getScoreData()===========");
        Dictionary<string, string> scoreDataStrings = this.scoreDataManager.getScoreDataDictionary();
        Debug.Log("========== " + scoreDataStrings + " ===========");
        return scoreDataStrings;
    }

    // テキストの表示
    private void displayText(string text){
        this.scoreText.text = text;
    }

    // スコアテキストの生成 nullを入れるとテストモードに
    private string scoreTextGenerator(Dictionary<string, string> scores){

        const string HEADAER = "Score List\n";
        const string FOOTER  = "End";

        const string INITIAL = "  > ";
        const string INDENT  = "       --- ";
        const string NEW_LINE = "\n";

        string clearScoreText = "";

        string[] scoreKey = new string[]{ScoreDataManager.SCORE_DATA_KEY_TIME, ScoreDataManager.SCORE_DATA_KEY_TANAKA, ScoreDataManager.SCORE_DATA_KEY_LIST};

        // スコアテキストの生成
        clearScoreText += HEADAER;
        if(scores == null){ // テスト用

            string testText = this.getTestText();
            clearScoreText += INITIAL + testText + NEW_LINE;

        }
        else{ // 本番用
            
            clearScoreText += INITIAL + "clear time" + NEW_LINE // クリアタイム
                            +       INDENT + scores[ScoreDataManager.SCORE_DATA_KEY_TIME] + NEW_LINE
                            + INITIAL + "attack count (Tanaka\'s PC)"  + NEW_LINE // 攻撃回数
                            +       INDENT + scores[ScoreDataManager.SCORE_DATA_KEY_TANAKA] + NEW_LINE
                            + INITIAL + "attack count (List-base)" + NEW_LINE // 攻撃回数
                            +       INDENT + scores[ScoreDataManager.SCORE_DATA_KEY_LIST] + NEW_LINE;

        }
        clearScoreText += FOOTER;

        return clearScoreText;
    }

    // スコアテキストの表示
    private void displayScoreText(Dictionary<string, string> scores){

        string scoreText = this.scoreTextGenerator(scores); // スコアテキストの生成
        this.displayText(scoreText); // スコアテキストの表示

    }




}




