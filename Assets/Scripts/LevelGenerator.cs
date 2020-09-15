using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject outsideCorner; // 1
    public GameObject outsideWall; // 2
    public GameObject insideCorner; // 3
    public GameObject insideWall; // 4
    public GameObject standardPallet; // 5
    public GameObject powerPallet; // 6
    public GameObject tJunction; // 7

    // 14 columns * 15 rows = 210 tiles
    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7}, // 0
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4}, // 1
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4}, // 2
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4}, // 3
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3}, // 4
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5}, // 5
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4}, // 6
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3}, // 7
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4}, // 8
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4}, // 9
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3}, // 10 
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0}, // 11
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0}, // 12
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0}, // 13
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0}, // 14
    };

    // Start is called before the first frame update
    void Start()
    {
        


        for (int row = 0; row < 15; row++) 
        { 
            for (int col = 0; col < 14; col++)
            {
                int tileNum = levelMap[row, col]; // store current tile number into a variable 
                if (tileNum != 0) // checks if its not 0 (empty tile)
                {
                    GameObject tile = GameObject.FindWithTag(tileNum + "");
                    GameObject rotateTile = GameObject.Instantiate(tile, new Vector3(col, -row, 0), Quaternion.identity);

                    if (tileNum == 1)
                    {
                        int x = 0; // rotate outsideCorner by 90
                        if (row == 9 && col == 0) { x += 90; }
                        if (row == 9 && col == 5) { x -= 90; } // ERROR
                        if (row == 13) { x += 180; }
                        rotateTile.transform.Rotate(0f, 0f, x);
                        
                    }


                    if(tileNum == 2) { 
                        if(row >= 1 && row <= 8)
                            rotateTile.transform.Rotate(0f, 0f, 90f);
                        if(row == 9 || row == 13)
                        {
                            rotateTile.transform.Rotate(0f, 0f, 180f);
                        }
                        if(row >= 10 && row <= 12)
                        {
                            rotateTile.transform.Rotate(0f, 0f, 270f);
                        }
                        
                    }

                    if(tileNum == 3)
                    {
                        if (row == 2 && (col == 5 || col == 11))
                        {

                            rotateTile.transform.Rotate(0f, 0f, 270f);
                        }
                        if (row == 6 && (col == 5 || col == 8))
                        {
                            rotateTile.transform.Rotate(0f, 0f, 270f);
                        }
                        if (row == 7 && col == 13)
                        {
                            rotateTile.transform.Rotate(0f, 0f, 270f);
                        }
                        if (row == 9 && col == 11) { rotateTile.transform.Rotate(0f, 0f, 270f); }

                        
                        

                        /*if((row == 2 || row == 6 || row == 7 || row == 9) && (col == 5 || col == 8 || col == 11 || col == 13)) { rotInCorner -= 90; }
                        if((row == 4 || row == 7 || row == 9 || row == 10 || row == 13) && (col == 2 || col == 7 || col == 8 || col == 10 || col == 13)) { rotInCorner += 90; }
                        
                        rotInCorner = 0;*/
                    }





                    if(tileNum == 4)
                    {
                        if(col == 5 || col == 8 || col == 11 | col == 13)
                        {
                            if(row >= 1 && row <= 3 || row >= 8 && row <= 9)
                                rotateTile.transform.Rotate(0f, 0f, 270f);
                        }
                    }



                    Debug.Log("Instantiated: " + tile);

                }
                Debug.Log("Row: " + row + " || Column: " + col + " || Tile Number: " + levelMap[row, col]);
            }
        }

        // Set all game object of the levelManager after instantiating the map
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
