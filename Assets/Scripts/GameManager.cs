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

        if (NetworkManager.Instance.HasToInitGame())
        {
            InitGame();
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void InitGame()
    {
        int boardSize = NetworkManager.Instance.getBoardSize();
        boardManager.Init(boardSize, boardSize);

        // place Obsticals
        boardManager.CreateObsticals();

        // Create Board
        boardManager.CreateBoard();


        // place Base
        Range rangeY;
        if (NetworkManager.Instance.HasToInitGame())
        {
            rangeY = new Range(0, boardSize / 2);
        }
        else
        {
            rangeY = new Range(0, (boardSize / 2) + 1);
        }
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
