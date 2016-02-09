using UnityEngine;
using System.Collections;

public class Matchmaker : Singleton<Matchmaker> {

    protected Matchmaker() {}

    public bool gameStarted;

	// Use this for initialization
	void Start () {

        gameStarted = false;

        PhotonNetwork.logLevel = PhotonLogLevel.Full;
	}

    public void MakeMatch()
    {
        Debug.Log("Start Matchmaking");
        PhotonNetwork.ConnectUsingSettings("v0.1"); // Connect to Lobby with GameVersion 0.1
        PhotonNetwork.automaticallySyncScene = true;
    }

    public void StopMatchmaking()
    {
        if (PhotonNetwork.connected)
        {
            PhotonNetwork.Disconnect();
        }
    }

    void OnConnectedToPhoton()
    {
        Menu.Instance.UpdateJoiningProgress("Joining Lobby...");
        if (PhotonNetwork.insideLobby)
        {
            Debug.Log("Inside Lobby");
        }
        else
        {
            Debug.Log("Connected to Photon. Not Inside Lobby");
            PhotonNetwork.JoinLobby();
        }
    }

    void OnJoinedLobby()
    {
        Debug.Log("Joining to Random Room");
        Menu.Instance.UpdateJoiningProgress("Joining Room...");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { maxPlayers = 2 }, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        if (PhotonNetwork.room.playerCount == 2)
        {
            Debug.Log("Room Full");
            PhotonNetwork.LoadLevel("Game");
            Menu.Instance.ToMenu("InGame");
            gameStarted = true;
        }
        else
        {
            Debug.Log("Room not Full");
            Menu.Instance.UpdateJoiningProgress("Waiting for Player to join...");
        }
    }

    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        if (PhotonNetwork.room.playerCount == 2)
        {
            Debug.Log("Room Full");
            PhotonNetwork.LoadLevel("Game");
            Menu.Instance.ToMenu("InGame");
            gameStarted = true;
        }
        else
        {
            Debug.Log("Room not Full");
            Menu.Instance.UpdateJoiningProgress("Waiting for Player to join...");
        }
    }

    
}
