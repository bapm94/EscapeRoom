using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Main_Game_Manager : MonoBehaviour
{
    private Scene nextScene;
    public static Main_Game_Manager instance;
    public bool aliceLevelStarted = false;
    [SerializeField] Texture2D cursor;

    #region tutorialManager
    public bool movedForWasd = false;
    public bool lookedForArrows = false;
    public bool objectsChecked = false;
    public bool tutorialActive3 = false;
    #endregion

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

        Cursor.lockState = CursorLockMode.Locked;

        //Cursor.SetCursor(cursor,Vector2.zero, CursorMode.Auto);
        
        //HidePointer(true);

    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            LeanTween.delayedCall(0.5f, () => Cursor.lockState = CursorLockMode.Locked);
            Cursor.visible = false;
        }
    }

    public void ChangeToScene(string newScene)
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
        SceneManager.LoadScene(newScene);
        if (newScene == "Alice_Kitchen_Scene") { aliceLevelStarted = true; }
        
    }

    public void ChangeToSceneButton(string newScene)
    {
        Main_Game_Manager.instance.ChangeToScene(newScene);

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

    //public void LockPointer(bool locked)
    //{
    //    if (locked)
    //    {
    //        //Cursor.visible = false;
    //        Cursor.lockState = CursorLockMode.Locked;
    //    }
    //}
    //public void HidePointer(bool hiden)
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = hiden;
    //    Debug.Log("game manager");
    //}
}
