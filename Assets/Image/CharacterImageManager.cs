using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterImageManager : MonoBehaviour
{
    // キャラクター数
    private const int CHARACTERS_SUM = 3;

    // キャラクター識別子
    public const string CHARACTER_NAME_MALLORY = "Mallory";

    // 感情(喜怒哀楽＋びっくり) 定数
    public const string EMOTIONS_HAPPY         = "HAPPY";        // 喜
    public const string EMOTIONS_ANGER         = "ANGERY";       // 怒
    public const string EMOTIONS_BLUE          = "BLUE";         // 哀
    public const string EMOTIONS_EXCITED       = "EXCITED";      // 楽
    public const string EMOTIONS_SURPRISE      = "SURPRISE";     // びっくり
    public const string EMOTIONS_EXCLAMATION   = "EXCLAMATION";  // びっくりマーク


    // キャラクターの画像
    // マロリー
    [SerializeField] private Sprite malloryEmotionsHappy;         // 喜
    [SerializeField] private Sprite malloryEmotionsAnger;         // 怒
    [SerializeField] private Sprite malloryEmotionsBlue;          // 哀
    [SerializeField] private Sprite malloryEmotionsExcited;       // 楽
    [SerializeField] private Sprite malloryEmotionsSurprise;      // びっくり
    [SerializeField] private Sprite malloryEmotionsExclamation;   // びっくり




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 指定したキャラクターの画像Dictionaryを渡す
    public Dictionary<string, Sprite> getCharacteImagesDictionary(string characteName){

        Dictionary<string, Sprite> characteImages = null;

        if(characteName == ""){ // キャラクターネームが空文字列の時

        }
        else if(characteName == CHARACTER_NAME_MALLORY){ // マロリー
            characteImages = this.malloryImageDictionaryGenerator();
        }

        return characteImages;
    }

    // マロリーの画像Dictionaryを生成
    private Dictionary<string, Sprite> malloryImageDictionaryGenerator(){

        // Dictionaryを宣言
        Dictionary<string, Sprite> malloryImages = new Dictionary<string, Sprite>();

        // 要素の追加
        malloryImages.Add(EMOTIONS_HAPPY,        this.malloryEmotionsHappy);        // 喜
        malloryImages.Add(EMOTIONS_ANGER,        this.malloryEmotionsAnger);        // 怒
        malloryImages.Add(EMOTIONS_BLUE,         this.malloryEmotionsBlue);         // 哀
        malloryImages.Add(EMOTIONS_EXCITED,      this.malloryEmotionsExcited);      // 楽
        malloryImages.Add(EMOTIONS_SURPRISE,     this.malloryEmotionsSurprise);     // びっくり
        malloryImages.Add(EMOTIONS_EXCLAMATION,  this.malloryEmotionsExclamation);  // びっくり

        return malloryImages;
    }




}
