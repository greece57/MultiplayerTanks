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

    public void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        Debug.Log("Player left!");
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("Menu");
        Menu.Instance.showMessage("Player disconnected");
        Menu.Instance.ToMenu("Main");
    }
}
