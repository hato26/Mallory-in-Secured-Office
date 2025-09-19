using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditor : MonoBehaviour
{

    // マップタイルの配置情報を獲得
    public int[][][] getMapData(){

        // map size
        const int mapSize_x = 25;
        const int mapSize_y = 15;

        // floor
        int[] floor_1 = new int[mapSize_x]{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        int[][] floorData =  new int[mapSize_y][]{floor_1, floor_1, floor_1, floor_1,  floor_1, floor_1, floor_1, floor_1, floor_1,  floor_1, floor_1, floor_1, floor_1, floor_1,  floor_1};

        // wall
        int[] wall_1      = new int[mapSize_x]{3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3};
        int[] wall_2      = new int[mapSize_x]{2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2,  2};
        int[] wall_3      = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] wall_4      = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] wall_5      = new int[mapSize_x]{0,  0,  0,  0,  0,  0, 18,  0,  0, 18,  0,  0,  0,  0,  0,  0, 18,  0,  0, 18,  0,  0,  0,  0,  0};
        int[] wall_6      = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] wall_7      = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] wall_8      = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] wall_9      = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] wall_10     = new int[mapSize_x]{0,  0,  0,  0,  0,  0, 18,  0,  0, 18,  0,  0,  0,  0,  0,  0, 18,  0,  0, 18,  0,  0,  0,  0,  0};
        int[] wall_11     = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] wall_12     = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] wall_13     = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] wall_14     = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] wall_15     = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[][] wallData  =  new int[mapSize_y][]{wall_15, wall_14, wall_13, wall_12, wall_11, wall_10, wall_9, wall_8, wall_7, wall_6, wall_5, wall_4, wall_3, wall_2, wall_1};
        
        // offic_1
        int[] offic_1_1   = new int[mapSize_x]{0, 15,  0,  0,  0, 15, 42, 28, 29,  0, 33, 35, 33, 34, 35,  0,  0, 28, 29,  0,  0,  0,  0,  0,  0};
        int[] offic_1_2   = new int[mapSize_x]{0, 14,  0, 50,  0, 14,  0, 30, 31,  0, 36, 38, 36, 37, 38,  0,  0, 30, 31,  0,  0, 26,  0,  0,  0};
        int[] offic_1_3   = new int[mapSize_x]{0, 13,  0,  0,  0, 13, 43,  0,  0,  0, 39, 41, 39, 40, 41, 43,  0,  0,  0,  0,  0, 27,  0,  0,  0};
        int[] offic_1_4   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_1_5   = new int[mapSize_x]{0,  0,  0,  0,  0, 10, 11, 12, 10, 11, 12,  0,  0,  0,  0, 10, 11, 12, 10, 11, 12,  0,  0,  0,  0};
        int[] offic_1_6   = new int[mapSize_x]{0,  0,  0,  0,  0,  7,  8,  9,  7,  8,  9,  0,  0,  0,  0,  7,  8,  9,  7,  8,  9,  0,  0,  0,  0};
        int[] offic_1_7   = new int[mapSize_x]{0,  0,  0,  0,  0,  4,  5,  6,  4,  5,  6,  0,  0,  0,  0,  4,  5,  6,  4,  5,  6,  0,  0,  0,  0};
        int[] offic_1_8   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_1_9   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_1_10  = new int[mapSize_x]{0,  0,  0,  0,  0, 10, 11, 12, 10, 11, 12,  0,  0,  0,  0, 10, 11, 12, 10, 11, 12,  0,  0,  0,  0};
        int[] offic_1_11  = new int[mapSize_x]{0,  0,  0,  0,  0,  7,  8,  9,  7,  8,  9,  0,  0,  0,  0,  7,  8,  9,  7,  8,  9,  0,  0,  0,  0};
        int[] offic_1_12  = new int[mapSize_x]{0,  0,  0,  0,  0,  4,  5,  6,  4,  5,  6,  0,  0,  0,  0,  4,  5,  6,  4,  5,  6,  0,  0,  0,  0};
        int[] offic_1_13  = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_1_14  = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_1_15  = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[][] officObjData_1 =  new int[mapSize_y][]{offic_1_15, offic_1_14, offic_1_13, offic_1_12, offic_1_11, offic_1_10, offic_1_9, offic_1_8, offic_1_7, offic_1_6, offic_1_5, offic_1_4, offic_1_3, offic_1_2, offic_1_1};

        // offic_2
        int[] offic_2_1   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_2_2   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_2_3   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 19,  0, 19, 19,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_2_4   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_2_5   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 19,  0,  0,  0,  0,  0};
        int[] offic_2_6   = new int[mapSize_x]{0,  0,  0,  0,  0, 19, 20, 22, 32, 23, 25,  0,  0,  0,  0, 32, 20, 22,  0,  0, 19,  0,  0,  0,  0};
        int[] offic_2_7   = new int[mapSize_x]{0,  0,  0,  0,  0,  0, 17,  0,  0, 16,  0,  0,  0,  0,  0,  0, 16,  0,  0, 16,  0,  0,  0,  0,  0};
        int[] offic_2_8   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_2_9   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_2_10  = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_2_11  = new int[mapSize_x]{0,  0,  0,  0,  0, 32, 23, 25, 19, 20, 22,  0,  0,  0,  0, 19, 21, 22, 32, 23, 25,  0,  0,  0,  0};
        int[] offic_2_12  = new int[mapSize_x]{0,  0,  0,  0,  0,  0, 16,  0,  0, 16,  0,  0,  0,  0,  0,  0, 16,  0,  0, 16,  0,  0,  0,  0,  0};
        int[] offic_2_13  = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_2_14  = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] offic_2_15  = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[][] officObjData_2 =  new int[mapSize_y][]{offic_2_15, offic_2_14, offic_2_13, offic_2_12, offic_2_11, offic_2_10, offic_2_9, offic_2_8, offic_2_7, offic_2_6, offic_2_5, offic_2_4, offic_2_3, offic_2_2, offic_2_1};

        // search
        int[] search_1    = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] search_2    = new int[mapSize_x]{0,  0,  0, 50,  0,  0,  0, 20, 20,  0,  0,  0,  0,  0,  0,  0,  0, 21, 21,  0,  0,  0,  0,  0,  0};
        int[] search_3    = new int[mapSize_x]{0,  2,  0,  0,  0,  0, 22,  0,  0,  0,  0,  0,  0,  0,  0, 23,  0,  0,  0,  0,  0,  3,  0,  0,  0};
        int[] search_4    = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] search_5    = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  0,  0,  0,  0};
        int[] search_6    = new int[mapSize_x]{0,  0,  0,  0,  0,  1,  0,  0,  0,  0, 90,  0,  0,  0,  0,  0, 91,  0,  0,  0,  1,  0,  0,  0,  0};
        int[] search_7    = new int[mapSize_x]{0,  0,  0,  0,  0,  1,  0,  0,  0,  0, 90,  0,  0,  0,  0,  4, 91,  0,  0,  0,  0,  1,  0,  0,  0};
        int[] search_8    = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  4,  0,  0,  0,  0,  0,  1,  0,  0,  0};
        int[] search_9    = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] search_10   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] search_11   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0, 71,  1, 80,  0,  0,  0,  0,  0, 60,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] search_12   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0, 71,  1, 80,  0,  0,  0,  0,  0, 60, 61,  0,  4,  0,  0,  0,  0,  0,  0};
        int[] search_13   = new int[mapSize_x]{0,  0,  0,  0,  0,  4,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  4,  0,  0,  0,  0,  0,  0};
        int[] search_14   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[] search_15   = new int[mapSize_x]{0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0};
        int[][] searchData =  new int[mapSize_y][]{search_15, search_14, search_13, search_12, search_11, search_10, search_9, search_8, search_7, search_6, search_5, search_4, search_3, search_2, search_1};

        // Players Area Of Activity
        int[] pleyer_1    = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_2    = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_3    = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_4    = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_5    = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_6    = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_7    = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_8    = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_9    = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_10   = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_11   = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_12   = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_13   = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_14   = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] pleyer_15   = new int[mapSize_x]{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[][] playersArea =  new int[mapSize_y][]{pleyer_15, pleyer_14, pleyer_13, pleyer_12, pleyer_11, pleyer_10, pleyer_9, pleyer_8, pleyer_7, pleyer_6, pleyer_5, pleyer_4, pleyer_3, pleyer_2, pleyer_1};

        // プレイヤー行動範囲の計算
        this.jaggedArrayAdder(playersArea, floorData);
        this.jaggedArrayAdder(playersArea, wallData);
        this.jaggedArrayAdder(playersArea, officObjData_1);
        this.jaggedArrayAdder(playersArea, officObjData_2);
        //this.jaggedArrayPrint(playersArea);

        // map data
        int[][][] mapData =  new int[][][]{floorData, wallData, officObjData_1, officObjData_2, searchData, playersArea};

        return mapData;
    }




// 2次のジャグ配列どうしの加算(0)
    private void jaggedArrayAdder(int[][] jag_a, int[][] jag_b){

        int elem = jag_a.Length;
        int column =  jag_a[0].Length;

        for(int i = 0; i < elem; i++ ){
            for(int j = 0; j < column; j++ ){
                jag_a[i][j] += jag_b[i][j];
            }
        }

        /*int i =0;
        foreach(var elem in jag_a){

            int j = 0;
            foreach(var column in elem){

                elem[j] = column + jag_b[i][j];
                j++;

            }

            i++;

        }*/

    }



    // 2次のジャグ配列の表示
    private void jaggedArrayPrint(int[][] jag){

        Debug.Log("<--------------->");
        foreach(var elem in jag){
            foreach(var column in elem){
                Debug.Log(column);
            }
        }
        Debug.Log("<--------------->");

    }






}


