using UnityEngine;
using System.Collections;

public class GameLoader : MonoBehaviour
{
    public GameObject gameManager;          //GameManager prefab to instantiate.
    public GameObject networkManager;       //SoundManager prefab to instantiate.


    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.Instance == null)
        {
            //Instantiate gameManager prefab
            Instantiate(gameManager);
        }

        if (NetworkManager.Instance == null)
        {
            Instantiate(networkManager);
        }
    }
}
