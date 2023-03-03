using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Game_Manager : MonoBehaviour
{
    private Scene nextScene;
    public static Main_Game_Manager instance;
    public bool aliceLevelStarted = false;

    void Start()
    {
        #region Singleton

        if (Main_Game_Manager.instance == null)
        {
            Main_Game_Manager.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        
    }

    public void ChangeToScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
        if (newScene == "Alice_Kitchen_Scene") { aliceLevelStarted = true; }
    }

    public void SaveAllData()
    {

    }

    public void ExitGame()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if PLATFORM_STANDALONE_WIN
        Application.Quit();
#endif
    }
}
