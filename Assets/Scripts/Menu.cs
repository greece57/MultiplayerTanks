using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    private string CurMenu;
    private string JoinProgress;

    public static Menu Instance;

	// Use this for initialization
	void Start () {
        Instance = this;
        CurMenu = "Main";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /*
     * Public Methods
     */

    public void UpdateJoiningProgress(string newProgress)
    {
        JoinProgress = newProgress;
    }

    public void StartGame()
    {

    }
    

    /*
     * Private Methods
     */

    void ToMenu(string menu)
    {
        CurMenu = menu;
    }

    void OnGUI() {
        if (CurMenu == "Main")
            Main();
        if (CurMenu == "Lobby")
            Lobby();
        if (CurMenu == "Joining")
            Joining();
    }

    private void Main()
    {
        if (GUI.Button(new Rect(0, 0, 128, 32), "Start"))
        {
            ToMenu("Lobby");
        }

    }

    private void Lobby()
    {
        if (GUI.Button(new Rect(0, 0, 128, 32), "Join Game"))
        {
            JoinProgress = "Connecting To Photon...";
            ToMenu("Joining");
        }
        if (GUI.Button(new Rect(0, 33, 128, 32), "Back"))
        {
            ToMenu("Main");
        }
    }

    private void Joining()
    {
        GUI.Label(new Rect(Screen.width / 2 - 64, Screen.height / 2, 256, 32), JoinProgress);
        
        // Make Match
        Matchmaker.Instance.MakeMatch();

        if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2 + 33, 128, 32), "Cancel"))
        {
            Matchmaker.Instance.StopMatchmaking();
            ToMenu("Lobby");
        }
    }
}
