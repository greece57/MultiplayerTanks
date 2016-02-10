using UnityEngine;
using System.Collections;

public class NetworkManager : Singleton<NetworkManager> {

    protected NetworkManager() {}

    public bool hasToInitGame
    {
        get{
            return PhotonNetwork.player.isMasterClient;
        }
    }

	// Use this for initialization
	void Awake () {
        PhotonNetwork.OnEventCall += this.OnInitializedBoard;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        Debug.Log("Player left!");
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("Menu");
        Menu.Instance.showMessage("Player disconnected");
        Menu.Instance.ToMenu("Main");
    }

    void OnInitializedBoard(byte eventcode, object content, int senderid)
    {
        if (eventcode == (byte) EventCode.InitializedBoard)
        {
            
        }
    }

    /*
     * public Methods
     */

    public int[] getBoardSize()
    {
        int boardSize = (int) PhotonNetwork.room.customProperties["boardSize"];
        Debug.Log("BoardSize: " + boardSize);
        return new int[]{boardSize, boardSize};
    }

    public void FinishedInitBoard(int boardRows, int boardColumns)
    {
        byte evCode = (byte) EventCode.InitializedBoard;
        byte content = 0;
        bool reliable = true;
        PhotonNetwork.RaiseEvent(evCode, content, reliable, null);
    }
}

public enum EventCode : byte
{
    InitializedBoard = 0,
    InitializedGame = 1
}
