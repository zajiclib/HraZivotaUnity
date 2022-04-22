using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows = 5;
    private int cols = 5;
    private int tileSize = 1;
    public GameObject WCell;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (float row = 0; row < rows; row++)
        {
            for (float col = 0; col < cols; col++)
            {
                Instantiate(WCell, new Vector3(col, row, 0), Quaternion.identity);
                //         |prefab|        |position|         |rotation|
                //         |prefab|   |transform.position|    |rotation|

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
