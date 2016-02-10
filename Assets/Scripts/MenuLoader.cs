using UnityEngine;
using System.Collections;

public class MenuLoader : MonoBehaviour {

    public GameObject matchMaker;
    public GameObject menuManager;

	// Use this for initialization
	void Awake () {

        if (Menu.Instance == null)
        {
            Instantiate(menuManager);
        }

        if (Matchmaker.Instance == null)
        {
            Instantiate(matchMaker);
        }
	
	}
}
