using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameraManager : MonoBehaviour
{

    // シリアライズ
    [SerializeField] private Vector2 baseAspect;
    [SerializeField] private float pixelPerUnit;

    // グローバル変数
    Camera mainCamera;





    // Start is called before the first frame update
    void Start()
    {

        // 初期化
        this.mainCamera = GetComponent<Camera>();
        //Vector2 screenSize = this.getScreenSize(); // スクリーンサイズの獲得

        // カメラサイズの更新
        this.updateCameraSize(this.baseAspect);

        
    }

    // 画面サイズの獲得
    private Vector2 getScreenSize(){

        float width = (float)Screen.width;
        float hright = (float)Screen.height;

        Vector2 scrSize = new Vector2(width, hright);

        return scrSize;
    }

    // アスペクト比の計算
    private float getaAspect(Vector2 asp){

        float result = asp.y / asp.x;

        return result;
    }

    // カメラサイズの更新
    private void updateCameraSize(Vector2 scrSize){
    
        //float size = (scrSize.y / this.pixelPerUnit) / 2.0f;
        float size = (scrSize.y / this.pixelPerUnit) / 2.0f;
        this.mainCamera.orthographicSize = size;
        
    }


}
