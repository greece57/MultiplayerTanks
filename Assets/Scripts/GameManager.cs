using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    protected GameManager() {}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

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
