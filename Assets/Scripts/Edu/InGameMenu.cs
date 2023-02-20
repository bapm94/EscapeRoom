using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject baseMenu;
    public static InGameMenu instance;
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeBaseMenuStatus(bool x)
    {
        baseMenu.SetActive(x);
        Main_Camera_Controller.instance.ChangeFollowStatus(!x);
    }

    public void ExitToLobby()
    {
        if(Main_Game_Manager.instance != null) { Main_Game_Manager.instance.ChangeToScene("LobbyScene"); }
    }
}
