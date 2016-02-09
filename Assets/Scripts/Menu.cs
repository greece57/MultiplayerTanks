using UnityEngine;
using System.Collections;

public class Menu : Singleton<Menu> {

    protected Menu() {}

    private string CurMenu;
    private string JoinProgress;
    private string Message;

	// Use this for initialization
	void Start () {
        CurMenu = "Main";
        Message = "";
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

    public void showMessage(string message)
    {
        Message = message;
    }

    public void ToMenu(string menu)
    {
        CurMenu = menu;
    }
    

    /*
     * Private Methods
     */

    void OnGUI() {
        if (CurMenu == "Main")
        {
            if (GUI.Button(new Rect(0, 0, 128, 32), "Start"))
            {
                ToMenu("Lobby");
            }
        }
        if (CurMenu == "Lobby")
            Lobby();
        if (CurMenu == "Joining")
            Joining();

        if (!Message.Equals(""))
        {
            GUI.Window(0, new Rect(Screen.width/2 - 128, Screen.height/2 - 32, 256, 64), HandleWindow, Message);
        }
    }

    private void HandleWindow(int windowID)
    {
        if (GUI.Button(new Rect(128-16, 64-24, 32, 16), "OK"))
        {
            Message = "";
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
