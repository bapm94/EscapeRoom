using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Manager_Lobby : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        if (Main_Game_Manager.instance == null) { Instantiate(gameManager); }
    }
}
