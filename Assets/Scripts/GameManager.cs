using UnityEngine;
using System;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    // Using Serializable allows us to embed a class with sub properties in the inspector.
    [Serializable]
    public class Range
    {
        public int minimum;             //Minimum value for our Count class.
        public int maximum;             //Maximum value for our Count class.


        //Assignment constructor.
        public Range(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    protected GameManager() {}

    private BoardManager boardManager;

	// Use this for initialization
	void Awake () {
        boardManager = GetComponent<BoardManager>();

        InitBoard();

        InitUnits();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void InitBoard()
    {
        int[] boardSize = NetworkManager.Instance.getBoardSize();
        boardManager.Init(boardSize[0], boardSize[1]);

        if (NetworkManager.Instance.hasToInitGame)
        {
            // place Obsticals
            boardManager.CreateObsticals();

            // Create Board
            boardManager.CreateBoard();
        }
    }

    private void InitUnits()
    {
        // place Base
        Range rangeY;
        Color playerColor;
        Vector2 unitPosition;
        Quaternion unitQuaternion;
        if (NetworkManager.Instance.hasToInitGame)
        {
            rangeY = new Range(0, boardManager.boardColumns / 2);
            playerColor = new Color(0, 0, 255);
            unitPosition = new Vector2(0, 0);
            unitQuaternion = Quaternion.identity;
        }
        else
        {
            rangeY = new Range((boardManager.boardColumns / 2) + 1, boardManager.boardColumns);
            playerColor = new Color(255, 0, 0);
            unitPosition = new Vector2(boardManager.boardRows - 1, boardManager.boardColumns - 1);
            unitQuaternion = Quaternion.Euler(0, 0, 180);
        }

        // Unit Manager
        GameObject tank = PhotonNetwork.Instantiate("Tank", new Vector3(unitPosition.x, unitPosition.y, -0.1f), unitQuaternion, 0);
        Transform body = tank.transform.FindChild("TankBody");
        body.GetComponent<SpriteRenderer>().color = playerColor;


        // place Base
        /*Vector2 basePosition = 
            new Vector2(UnityEngine.Random.Range(0, boardManager.boardRows), UnityEngine.Random.Range(rangeY.minimum, rangeY.maximum));
        Debug.Log(nameBase);
        Debug.Log(basePosition.x);
        Debug.Log(basePosition.y);
        PhotonNetwork.Instantiate(nameBase, new Vector3(basePosition.x, basePosition.y, -0.1f), Quaternion.identity, 0);
        */
    }

    /*
     * public Methods
     */

    public void PauseGame()
    {
        // pause Game
        // grey Overlay over Game (but not over GUI!)
        // send Command that Game is Paused
    }

    public void UnpauseGame()
    {
        // unpause Game
        // remove grey Overlay
        // send Command that Game is Resumed
    }

    public void QuitGame()
    {
        // stop Game (surrender)
        NetworkManager.Instance.Disconnect();
    }
}
