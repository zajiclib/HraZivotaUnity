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

    public Material blackMaterial;

    public Material whiteMaterial;


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

        int stredY = cols / 2;

        int stredX = rows / 2;

        float x = WCells[stredX, stredY].transform.position.x;
        float y = WCells[stredX, stredY].transform.position.y;
        float z = WCells[stredX, stredY].transform.position.z;

        m_MainCamera.transform.Translate(x,y,z);
        //m_MainCamera.Position = new Vector3(WCells[stredX, stredY].)
        // WCells[stredX, stredY];
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
        if (WCells != null && WCells.Length > 0)
        {
            System.Random random = new System.Random();

            int xRandom = random.Next(0, rows);
            int yRandom = random.Next(0, cols);

            SpriteRenderer sp = WCells[xRandom, yRandom].GetComponent<SpriteRenderer>();

            sp.sprite = null;

            bool isWhite = random.Next(0, 2) == 0;

            Debug.Log(isWhite);


            sp.material = isWhite ? whiteMaterial : blackMaterial;
        }   
    }


    // Update is called once per frame
    void Update()
    {
        UpdateCellGrid();

    }
}
