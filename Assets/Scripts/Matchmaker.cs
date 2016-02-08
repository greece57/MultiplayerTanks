using UnityEngine;
using System.Collections;

public class Matchmaker : MonoBehaviour {

    public static Matchmaker Instance;

	// Use this for initialization
	void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        PhotonNetwork.logLevel = PhotonLogLevel.Full;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MakeMatch()
    {
        Debug.Log("Start Matchmaking");
        PhotonNetwork.ConnectUsingSettings("v0.1"); // Connect to Lobby with GameVersion 0.1
        PhotonNetwork.automaticallySyncScene = true;
    }

    public void StopMatchmaking()
    {
        if (PhotonNetwork.inRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        if (PhotonNetwork.insideLobby)
        {
            PhotonNetwork.LeaveLobby();
        }
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
            Menu.Instance.StartGame();
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
            Menu.Instance.StartGame();
        }
        else
        {
            Debug.Log("Room not Full");
            Menu.Instance.UpdateJoiningProgress("Waiting for Player to join...");
        }
    }

    
}
