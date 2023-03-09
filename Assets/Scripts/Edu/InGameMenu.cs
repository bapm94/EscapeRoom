using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject baseMenu;
    public GameObject settingsMenu;
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
        if ( x == true)
        {
            Main_Camera_Controller.instance.ChangeFollowStatus(!x);
            Time.timeScale = 0.0f;
        }
        if (!Main_Character_Controller_v2.instance.isAnalizingOject && x == false)
        {
            Main_Camera_Controller.instance.ChangeFollowStatus(!x);
            Time.timeScale = 1.0f;
        }
    }

    public void ExitToLobby()
    {
        if(Main_Game_Manager.instance != null) { Main_Game_Manager.instance.ChangeToScene("LobbyScene"); }
    }
}
