using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {

    private Transform tank;
    private Transform body;
    private Transform tower;
    private PhotonView pView;
    private Canvas tankUI;

	// Use this for initialization
	void Start () {
        tank = GetComponent<Transform>();
        body = tank.FindChild("TankBody");
        tower = tank.FindChild("TankTower");
        pView = GetComponent<PhotonView>();
        tankUI = tank.FindChild("TankCanvas").GetComponent<Canvas>();
        tankUI.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnMouseDown()
    {
        Debug.Log("TUUT");
        tankUI.enabled = !tankUI.enabled;
    }

    public void OnClickMove()
    {
        Debug.Log("MOVE BITCH");
    }

    public void OnClickShoot()
    {
        Debug.Log("Shoot bitch");
    }
}
