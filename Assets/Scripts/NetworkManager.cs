using UnityEngine;
using System.Collections;

public class NetworkManager : Singleton<NetworkManager> {

    protected NetworkManager() {}

	// Use this for initialization
	void Start () {
	
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

    /*
     * public Methods
     */

    public int getBoardSize()
    {
        int boardSize = (int) PhotonNetwork.room.customProperties["boardSize"];
        return boardSize;
    }

    public bool HasToInitGame()
    {
        return PhotonNetwork.player.isMasterClient;
    }
}
