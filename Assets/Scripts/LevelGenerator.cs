using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject outsideCorner;
    public GameObject outsideWall;
    public GameObject insideCorner;
    public GameObject insideWall;
    public GameObject standardPallet;
    public GameObject powerPallet;
    public GameObject tJunction;

    // 14 columns * 15 rows = 210 tiles
    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    // Start is called before the first frame update
    void Start()
    {
        for (int row = 0; row < 15; row++) 
        { 
            for (int col = 0; col < 14; col++)
            {
                if (levelMap[row, col] != 0)
                {
                    GameObject tile = GameObject.FindWithTag(levelMap[row, col] + "");
                    if (tile != null)
                    {
                        Instantiate(tile, new Vector3(col, -row, 0), Quaternion.identity);
                        Debug.Log("Instantiated: " + tile);
                    } 
                    
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
