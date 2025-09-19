using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MalloryConroler : MonoBehaviour
{

    private Animator testerAnimator;
    private int animationNum = 0;
    private float distance = 1.0f;
    private float velocity = 3.0f;
    private Vector3 startPosition;
    private Vector3 direction;
    private Vector3 targetPosition;

    // スワイプ時の入力方向
    private Vector3 swipePosition;

    // タップ位置の保持
    private Vector3 tapePosition;

    // マップ情報
    GameObject mapMaker;
    MapGnerater mapData;

    private int[][] playersSearchData; // プレイヤー調査範囲
    //private Vector2Int playersSearchIndex;
    private searchEventManager searchEvent;

    private int[][] playersAreaOfActivityData; // プレイヤー行動範囲
    private Vector2Int playersAreaIndex;
    private Vector2Int startPlayerIndex;

	// プレイヤーキャラクターのスケール
	private Vector3  characterScale;

    // UI情報の保持
    [SerializeField]
    private GameObject uiCanvas;


    // Start is called before the first frame update
    void Start()
    {

        // 初期値
        this.testerAnimator = GetComponent<Animator>(); // マロリーのアニメーターを獲得
        this.startPosition = transform.position; // マロリーのスタート位置を獲得
		this.startPlayerIndex = new Vector2Int( (int)(this.startPosition.x), (int)(this.startPosition.y) );
        this.direction = this.startPosition;
        this.targetPosition = this.startPosition;
        //this.playersSearchIndex = this.startPlayerIndex;
        this.playersAreaIndex = this.startPlayerIndex;


        // プレイヤーキャラクターのスケールを獲得
		this.characterScale = this.transform.localScale;


        // マップデータ
        this.mapMaker = GameObject.Find("MapMaker");
        this.mapData = mapMaker.GetComponent<MapGnerater>();

        // プレイヤー調査範囲＆行動範囲を獲得
        this.playersSearchData = mapData.getPlayersSearchData();
        this.playersAreaOfActivityData = mapData.getPlayersAreaOfActivityData();

        // 調査イベント コルーチンを使うためAddComponentで生成
        this.gameObject.AddComponent<searchEventManager>();
        this.searchEvent = gameObject.GetComponent<searchEventManager>();
        this.searchEvent.initializeSearchEventManager(this.playersSearchData); // 初期化

    }

    // Update is called once per frame
    void Update()
    {
    
        // testerの位置を獲得
        Vector3 position = transform.position;

        // UIがアクティブなとき実行しない
        bool uiActiveFlag = this.getActiveUIFlag();
		//Debug.Log("this.getActiveUIFlag() : " + uiActiveFlag);
        if(!uiActiveFlag){

            // 調査イベント(画面をタップやクリックしたら)
            bool tapeFlag = this.getTapFlag();
            if(tapeFlag){
                //プレイヤーの向いている方向にプラス１したグリッド座標のインデックスを生成
                Vector2Int searchIndex = new Vector2Int( (int)(position.x + this.direction.x), (int)(position.y + this.direction.y) );
                // イベント番号を獲得したのち、イベントを発生させる。
                int eventNumber = this.searchEvent.getSearchEventNumber(searchIndex);
                this.searchEvent.searchEvent(eventNumber);
            }

            // testerの位置を更新
            position = charaControl(position);
            transform.position = Vector3.MoveTowards(transform.position, position, velocity * Time.deltaTime);

        }

    }

    // UIがアクティブかどうか アクティブなときtrue
    private bool getActiveUIFlag(){

        bool avtiveFlag = false;
        int childCount = this.uiCanvas.transform.childCount; // 子オブジェクトの総数を獲得

        // 子オブジェクトがアクティブかどうか　どれかがアクティブなときtrue
        for(int i = 0; i < childCount; i++ ){

            Transform uiPanelTransform = this.uiCanvas.transform.GetChild(i); // 子オブジェクトのトランスフォームの獲得
            GameObject uiPanel = uiPanelTransform.gameObject; // トランスフォームからゲームオブジェクトを獲得

            // UIがアクティブかどうか　アクティブなときtrueを代入しbreak
			bool active = uiPanel.activeInHierarchy;
			//Debug.Log("UI active : " + active);
            if(active){

                avtiveFlag = true;
                break; // ループを抜ける

            }

        }

        return avtiveFlag;
    }

    // ベクトルの成分を -1, 0, 1 に整理する
    private Vector3 getSwipeDirectionVector(Vector3 sdVector){

        Vector3 swipeDirectionVector = new Vector3(0, 0, 0);

        // ベクトルの各要素の絶対値を取る
        float absSdVector_x = Math.Abs(sdVector.x);
        float absSdVector_y = Math.Abs(sdVector.y);

        // X軸とY軸のどちらの絶対値が大きいか
        if(absSdVector_x > absSdVector_y){ // X軸成分の絶対値が大きい

            if(sdVector.x > 0){ // X軸成分が0超過
                swipeDirectionVector.x = 1;
            }
            else if(sdVector.x < 0){ // X軸成分が0未満
                swipeDirectionVector.x = -1;
            }

        }
        else if(absSdVector_x < absSdVector_y){ // Y軸成分の絶対値が大きい

            if(sdVector.y > 0){ // Y軸成分が0超過
                swipeDirectionVector.y = 1;
            }
            else if(sdVector.y < 0){ // Y軸成分が0未満
                swipeDirectionVector.y = -1;
            }

        }
        
        return swipeDirectionVector;
    }

    // スワイプ操作の入力を取る(上下左右)
    private Vector3 getSwipeDirection(){

        Vector3 swipeDirection = new Vector3(0, 0, 0);

        bool inputTapDownFlag = Input.GetMouseButtonDown(0); // 画面をタップした瞬間(タップしたかどうか)
        bool inputTapFlag = Input.GetMouseButton(0);         // 画面をタップしている期間

        // タップしたかどうかの判定
        if(inputTapDownFlag){
            this.swipePosition = Input.mousePosition; // タップした場所の座標を獲得
        }
        else if(inputTapFlag){

            Vector3 newSwipePosition = Input.mousePosition; // タップし続けている場所の座標を獲得

            // スワイプ方向の計算
            Vector3 swipeVector = newSwipePosition - this.swipePosition;
            swipeDirection = getSwipeDirectionVector(swipeVector);

        }

        return swipeDirection;
    }

    // タップしたかどうかの判定(上下左右)
    private bool getTapFlag(){

        bool tapeFlag = false;
        bool inputTapDownFlag = Input.GetMouseButtonDown(0); // 画面をタップした瞬間(タップしたかどうか)
        bool inputTapUpFlag = Input.GetMouseButtonUp(0);     // 画面をタップしている期間

        // タップしたかどうかの判定
        if(inputTapDownFlag){
            this.tapePosition = Input.mousePosition; // タップした瞬間の場所の座標を獲得
        }
        else if(inputTapUpFlag){

            Vector3 newTapePosition = Input.mousePosition; // タップし終えた場所の座標を獲得
        
            // 保持している座標とタップし終えた座標が同じならタップしたことにする
            if(this.tapePosition == newTapePosition){
                tapeFlag = true;
            }
        
        }

        return tapeFlag;
    }


    // プレイヤーの行動範囲の判定
    private bool playersAreaOfActivity(int[][] data, Vector2Int index){

        bool result = false;

        int elem = data.Length;
        int column = data[0].Length;
        int num;

        // 参照エラーの対策
        if( (index.x >= 0 && index.x < column) && (index.y >= 0 && index.y < elem)){

           // Debug.Log(index);

            num = data[index.y][index.x];

            // 1の時プレイヤーは進める(trueを返す)
            if(num == 1){
                result = true;
            }

        }

        return result;
    }

    // testerのコントロール(移動、アニメーション)
    private Vector3 charaControl(Vector3 position){

        Vector3 dir = this.getSwipeDirection();
        float x = dir.x;
        float y = dir.y;

        if(dir != Vector3.zero && this.targetPosition == position){
            
            // プレイヤーの向きの保存
            this.direction.x = dir.x;
            this.direction.y = dir.y;

            // プレイヤーが移動可能かの判定
            int tar_x = this.playersAreaIndex.x + (int)x;
            int tar_y = this.playersAreaIndex.y + (int)y;
            Vector2Int tarPlayerIndex = new Vector2Int(tar_x, tar_y);
            bool areaFlag = this.playersAreaOfActivity(this.playersAreaOfActivityData, tarPlayerIndex);

            if(areaFlag){

                // プレイヤーの実数座標、グリッド座標の更新
                targetPosition += dir * this.distance;
                this.playersAreaIndex = tarPlayerIndex;

            }

        }

        // アニメーション制御　右　左　上　下
        if(x > 0){ // 横

			this.transform.localScale = new Vector3( this.characterScale.x * (-1), this.characterScale.y, this.characterScale.z ); // 反対向きに
            this.animationNum = 3;

        }
        else if(x < 0){ // 横

			this.transform.localScale = this.characterScale; // 元の向きに
            this.animationNum = 3;

        }
        else if(y < 0){ // 前
            this.transform.localScale = this.characterScale; // 元の向きに
            this.animationNum = 1;
        }
        else if(y > 0){ // 後ろ
            this.transform.localScale = this.characterScale; // 元の向きに
            this.animationNum = 2;
        }
		else{
			this.animationNum = 0;
		}

        // アニメーションの切り替え
        testerAnimator.SetInteger("num", this.animationNum);

        return targetPosition;
    }

 



}







