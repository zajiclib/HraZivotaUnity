using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows = 10;
    private int cols = 5;
    private int tileSize = 1;
    public GameObject WCell;
    private GameObject [,] WCells;
    Camera m_MainCamera;


    // Start is called before the first frame update
    void Start()
    {
        WCells = GenerateGrid();

        m_MainCamera = Camera.main;

        ShiftCamera();

        // GenerateGrid();
    }

    void ShiftCamera()
    {
        if (m_MainCamera == null) return;

        // 5/2 = 2.5 ....math.floor()
        int stredY = cols / 2;

        int stredX = rows / 2;

        float x = WCells[stredX, stredY].transform.position.x;
        float y = WCells[stredX, stredY].transform.position.y;
        float z = WCells[stredX, stredY].transform.position.z;

        m_MainCamera.transform.Translate(x,y,z);
        //m_MainCamera.Position = new Vector3(WCells[stredX, stredY].)
        //WCells[stredX, stredY].GetComponent().;
    }




    
    private GameObject [,] GenerateGrid()
    {
        GameObject[,] resultGrid = new GameObject[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                resultGrid[row, col] = Instantiate(WCell, new Vector3(col, row, 0), Quaternion.identity);
                //                               |prefab|        |position|         |rotation|
                //                               |prefab|   |transform.position|    |rotation|  popřípadě |parent|
                
            }
        }

        return resultGrid;
    }


    private void UpdateCellGrid()
    {
        Debug.Log(WCells.Length);       
    }


    // Update is called once per frame
    void Update()
    {
        //UpdateCellGrid();

    }
}
