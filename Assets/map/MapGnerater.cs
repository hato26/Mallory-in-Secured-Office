using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapGnerater : MonoBehaviour
{

    // シリアライズ
    [SerializeField] GameObject bgObj_door; // door
    [SerializeField] GameObject bgObj_floor; // floor
    [SerializeField] GameObject bgObj_wall_1; // wall
    [SerializeField] GameObject bgObj_wall_2; // wall
    [SerializeField] GameObject bgObj_desk_1_1; // desk
    [SerializeField] GameObject bgObj_desk_1_2; // desk
    [SerializeField] GameObject bgObj_desk_1_3; // desk
    [SerializeField] GameObject bgObj_desk_2_1; // desk
    [SerializeField] GameObject bgObj_desk_2_2; // desk
    [SerializeField] GameObject bgObj_desk_2_3; // desk
    [SerializeField] GameObject bgObj_desk_3_1; // desk
    [SerializeField] GameObject bgObj_desk_3_2; // desk
    [SerializeField] GameObject bgObj_desk_3_3; // desk
    [SerializeField] GameObject bgObj_plant_1; // plant
    [SerializeField] GameObject bgObj_plant_2; // plant
    [SerializeField] GameObject bgObj_plant_3; // plant
    [SerializeField] GameObject bgObj_chair_red_bak; // chair
    [SerializeField] GameObject bgObj_chair_blue_front; // chair
    [SerializeField] GameObject bgObj_book_tower; // book    
    [SerializeField] GameObject bgObj_display_white_1; // display_white
    [SerializeField] GameObject bgObj_display_white_2;
    [SerializeField] GameObject bgObj_pc_white; // pc_white
    [SerializeField] GameObject bgObj_display_black_1; // display_black
    [SerializeField] GameObject bgObj_display_black_2;
    [SerializeField] GameObject bgObj_pc_black; // pc_black
    [SerializeField] GameObject bgObj_server_1; // server
    [SerializeField] GameObject bgObj_server_2;
    [SerializeField] GameObject bgObj_whiteBoard_1; // whiteBoard
    [SerializeField] GameObject bgObj_whiteBoard_2;
    [SerializeField] GameObject bgObj_whiteBoard_3;
    [SerializeField] GameObject bgObj_whiteBoard_4;
    [SerializeField] GameObject bgObj_telephone; // telephone
    [SerializeField] GameObject bgObj_bookShelf_1; // bookShelf
    [SerializeField] GameObject bgObj_bookShelf_2;
    [SerializeField] GameObject bgObj_bookShelf_3;
    [SerializeField] GameObject bgObj_bookShelf_4;
    [SerializeField] GameObject bgObj_bookShelf_5;
    [SerializeField] GameObject bgObj_bookShelf_6;
    [SerializeField] GameObject bgObj_bookShelf_7;
    [SerializeField] GameObject bgObj_bookShelf_8;
    [SerializeField] GameObject bgObj_bookShelf_9;
    [SerializeField] GameObject bgObj_timer; // timer
    [SerializeField] GameObject bgObj_dustBOX; // dustBOX
    


    // グローバル変数
    private int[][] playersSearchData;
    private int[][] playersAreaOfActivityData;



    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Run : MapGnerater");

        // マップの生成 MapEditorのgetMapData() からジャグ配列を獲得後,調査範囲と行動範囲のデータを除いたジャグ配列でマップを生成
        MapEditor officMap = new MapEditor();
        int[][][] mapDataTemp = officMap.getMapData();
        int[][][] mapData = new int[][][]{mapDataTemp[0], mapDataTemp[1], mapDataTemp[2], mapDataTemp[3]};
        this.CreateObj_OfficeMap(mapData);

        // 獲得後調査範囲と行動範囲のデータをグローバル変数に格納
        this.playersSearchData = mapDataTemp[4];
        this.playersAreaOfActivityData = mapDataTemp[5];



    }

    // Update is called once per frame
    void Update()
    {

        //this.cont++;

        
    }

    // geter関数
    // プレイヤー調査範囲
    public int[][] getPlayersSearchData(){
        return playersSearchData;
    }

    // プレイヤー行動範囲
    public int[][] getPlayersAreaOfActivityData(){
        return playersAreaOfActivityData;
    }


    // マップデータからマップを生成
    private void CreateObj_OfficeMap(int[][][] mapData){

        Vector3 mapingPosition = Vector3.zero;
        const float add = 1.0f;
        const float reset = 0.0f;

        foreach(var depth in mapData){

            foreach(var elem in depth){

                foreach(var column in elem){
                    
                    if(column == 1){

                        // floor
                        GameObject bgFloor = Instantiate(bgObj_floor, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 2){

                        // wall_1
                        GameObject bgWall_1 = Instantiate(bgObj_wall_1, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 3){

                        // wall_2
                        GameObject bgWall_2 = Instantiate(bgObj_wall_2, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 4){

                        // desk_1_1
                        GameObject bgDesk_1_1 = Instantiate(bgObj_desk_1_1, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 5){

                        // desk_1_2
                        GameObject bgDesk_1_2 = Instantiate(bgObj_desk_1_2, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 6){

                        // desk_1_3
                        GameObject bgDesk_1_3 = Instantiate(bgObj_desk_1_3, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 7){

                        // desk_2_1
                        GameObject bgDesk_2_1 = Instantiate(bgObj_desk_2_1, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 8){

                        // desk_2_2
                        GameObject bgDesk_2_2 = Instantiate(bgObj_desk_2_2, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 9){

                        // desk_2_3
                        GameObject bgDesk_2_3 = Instantiate(bgObj_desk_2_3, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 10){

                        // desk_3_1
                        GameObject bgDesk_3_1 = Instantiate(bgObj_desk_3_1, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 11){

                        // desk_3_2
                        GameObject bgDesk_3_2 = Instantiate(bgObj_desk_3_2, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 12){

                        // desk_3_3
                        GameObject bgDesk_3_3 = Instantiate(bgObj_desk_3_3, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 13){

                        // plant_1
                        GameObject bgplant_1 = Instantiate(bgObj_plant_1, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 14){

                        // plant_2
                        GameObject bgPlant_2 = Instantiate(bgObj_plant_2, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 15){

                        // plant_3
                        GameObject bgPlant_3 = Instantiate(bgObj_plant_3, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 16){

                        // chair_red_bak　＜重複＞
                        GameObject bgChair_red_bak = Instantiate(bgObj_chair_red_bak, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 17){

                        // chair_red_bak
                        GameObject bgChair_red_bak = Instantiate(bgObj_chair_red_bak, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 18){

                        // chair_blue_front
                        GameObject bgChair_blue_front = Instantiate(bgObj_chair_blue_front, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 19){

                        // book_tower
                        GameObject bgBook_tower = Instantiate(bgObj_book_tower, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 20){

                        // display_white
                        GameObject bgDisplay_white_1 = Instantiate(bgObj_display_white_1, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 21){

                        // display_white
                        GameObject bgDisplay_white_2 = Instantiate(bgObj_display_white_2, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 22){

                        // pc_white
                        GameObject bgPc_white = Instantiate(bgObj_pc_white, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 23){

                        // display_black
                        GameObject bgDisplay_black_1 = Instantiate(bgObj_display_black_1, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 24){

                        // display_black
                        GameObject bgDisplay_black_2 = Instantiate(bgObj_display_black_2, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 25){

                        // display_black
                        GameObject bgPc_black = Instantiate(bgObj_pc_black, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 26){

                        // server
                        GameObject bgServer_1 = Instantiate(bgObj_server_1, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 27){

                        // server
                        GameObject bgServer_2 = Instantiate(bgObj_server_2, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 28){ // 1

                        // whiteBoard
                        GameObject bgWhiteBoard_1 = Instantiate(bgObj_whiteBoard_1, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 29){ // 2

                        // whiteBoard
                        GameObject bgWhiteBoard_2 = Instantiate(bgObj_whiteBoard_2, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 30){ // 3

                        // whiteBoard
                        GameObject bgWhiteBoard_3 = Instantiate(bgObj_whiteBoard_3, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 31){ // 4

                        // whiteBoard
                        GameObject bgWhiteBoard_4 = Instantiate(bgObj_whiteBoard_4, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 32){

                        // telephone
                        GameObject bgTelephone = Instantiate(bgObj_telephone, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 33){ // 1

                        // bookShelf
                        GameObject bgbookShelf_1 = Instantiate(bgObj_bookShelf_1, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 34){ // 2

                        // bookShelf
                        GameObject bgbookShelf_2 = Instantiate(bgObj_bookShelf_2, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 35){ // 3

                        // bookShelf
                        GameObject bgbookShelf_3 = Instantiate(bgObj_bookShelf_3, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 36){ // 4

                        // bookShelf
                        GameObject bgbookShelf_4 = Instantiate(bgObj_bookShelf_4, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 37){ // 5

                        // bookShelf
                        GameObject bgbookShelf_5 = Instantiate(bgObj_bookShelf_5, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 38){ // 6

                        // bookShelf
                        GameObject bgbookShelf_6 = Instantiate(bgObj_bookShelf_6, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 39){ // 7

                        // bookShelf
                        GameObject bgbookShelf_7 = Instantiate(bgObj_bookShelf_7, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 40){ // 8

                        // bookShelf
                        GameObject bgbookShelf_8 = Instantiate(bgObj_bookShelf_8, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 41){ // 9

                        // bookShelf
                        GameObject bgbookShelf_9 = Instantiate(bgObj_bookShelf_9, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 42){

                        // timer
                        GameObject bgtimer = Instantiate(bgObj_timer, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 43){

                        // bookShelf
                        GameObject bgdustBOX = Instantiate(bgObj_dustBOX, mapingPosition, Quaternion.identity);

                    }
                    else if(column == 50){

                        // door
                        GameObject bgDoor = Instantiate(bgObj_door, mapingPosition, Quaternion.identity);
                        bgDoor.name = "Exit";
                        bgDoor.AddComponent<doorController>();

                    }
                    
                    

                    mapingPosition.x += add; // 描画位置を更新(x)
                }

                mapingPosition.x = reset; // 描画位置をリセット(x)
                mapingPosition.y += add;// 描画位置を更新(y)

            }

            mapingPosition.y = reset; // 描画位置をリセット(y)

        }

    }



}



