using UnityEngine;
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

    public static readonly float BOARD_Z_VALUE = 0;

    public int boardRows;
    public int boardColumns;

    private Transform boardHolder;
    private List<Vector2> obsticals;

    public void Init(int rows, int columns)
    {
        boardRows = rows;
        boardColumns = columns;

        obsticals = new List<Vector2>();
    }

	public void CreateBoard()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = 0; x < boardRows; x++)
        {
            for (int y = 0; y < boardColumns; y++)
            {
                Vector2 newPosition = new Vector2(x, y);

                GameObject instance;
                if (obsticals.Contains(newPosition))
                {
                    instance =
                            PhotonNetwork.Instantiate("BoardTileObstical", new Vector3(x, y, BOARD_Z_VALUE), Quaternion.identity, 0) as GameObject;
                }
                else
                {
                    instance =
                            PhotonNetwork.Instantiate("BoardTile", new Vector3(x, y, BOARD_Z_VALUE), Quaternion.identity, 0) as GameObject;
                }

                instance.transform.SetParent(boardHolder);
            }
        }

        // release obsticals
        obsticals = null;

        NetworkManager.Instance.FinishedInitBoard(boardRows, boardColumns);

    }

    public void CreateObsticals()
    {
        int maxObsticals = (int) (boardRows * boardColumns * 0.05);
        int countObsticals = Random.Range(1, maxObsticals);
        for (int i = 0; i < countObsticals; i++)
        {
            Vector2 newObstical = new Vector2(Random.Range(0, boardRows), Random.Range(0, boardColumns));
            if (!obsticals.Contains(newObstical))
            {
                obsticals.Add(newObstical);
            }
        }
    }
}
