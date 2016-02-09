using UnityEngine;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

    public int boardRows;
    public int boardColumns;

    public GameObject boardTile;

    private Transform boardHolder;

	public void CreateBoard(int rows, int columns)
    {
        boardHolder = new GameObject("Board").transform;

        boardRows = rows;
        boardColumns = columns;

        for (int x = 0; x <= boardRows; x++)
        {
            for (int y = 0; y <= boardColumns; y++)
            {
                GameObject instance =
                        Instantiate(boardTile, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }

    }
}
