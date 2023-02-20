using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGame_Menu_Controller : MonoBehaviour
{
    public CinemachineVirtualCamera[] cams; //different cameras to choose from
    public Button[] writtenButtons; //buttons used in the book
    public GameObject[] levels;
    [SerializeField] int currentLevel;
    [SerializeField] Animator animator;
    float canPress;

    int currentCamera; //current camera being used
    bool isInCam; //true if player is currently using any of the menu cameras
    bool canMove;

    public static InGame_Menu_Controller instance;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "LobbyScene")
        {
            this.enabled = false;
        }
    }
    private void Start()
    {
        canMove = true;
        if (instance == null) { InGame_Menu_Controller.instance = this; }
        else { Destroy(this); }

        //disables buttons, sets camera to player
        for (int i = 0; i < writtenButtons.Length; i++)
        {
            writtenButtons[i].interactable = false;
        }
        GoBackToPlayerCam();
    }

    void Update()
    {
        if (currentCamera == 1)
        {
            for (int i = 0; i < writtenButtons.Length; i++)
            {
                writtenButtons[i].interactable = true;
            }
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame) 
        { 
            if (currentCamera == 5)
            {
                StartCoroutine(BackToLevelMenu());
            }
            else { GoBackToPlayerCam(); /*BackWithBooks();*/ }
        }

        NavigateLevelMenu();
        NavigateMenu();

        canPress += Time.deltaTime; //timer from NavigateLevelMenu()
        /*if (animator.GetCurrentAnimatorStateInfo(0).IsName("Level1BookChosen")) 
        { 
            canPress = -1.0f;
            animator.ResetTrigger("Book1Play");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Level1BookChosen -1"))
        {
            animator.ResetTrigger("Book1Back");
        }*/
    }

    public void BackWithBooks()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].GetComponent<Chosen_Level>().isCurrentlyActive = false;
            levels[i].GetComponent<Chosen_Level>().ActiveCheck();
        }
    }
    /// <summary>
    /// gets camera back to player view
    /// </summary>
    public void GoBackToPlayerCam()
    {
        if (currentCamera != 0 && canMove)
        {            
            isInCam = false;
            currentCamera = 0;
            IndexChange(currentCamera); //this is what changes the camera
            currentLevel = 0;
            animator.Play("BookIdle");
            for (int i = 0; i < writtenButtons.Length; i++) //disables button interactability
            {
                writtenButtons[i].interactable = false;
            }

            if (Main_Camera_Controller.instance != null) { Main_Camera_Controller.instance.ChangeFollowStatus(true); }
        }
    }

    /// <summary>
    /// navigation throughout the level menu and delay between inputs to avoid bugging
    /// </summary>
    public void NavigateLevelMenu()
    {
        if (isInCam && currentCamera == 4)
        {
            if (canPress > 1.33f)
            {
                if (Keyboard.current.aKey.wasPressedThisFrame)
                {
                    /*if (currentLevel < 1) { currentLevel++; }
                    else { currentLevel = 0; }*/
                    if (currentLevel == 1) { currentLevel = 0; }
                    else { currentLevel = 1; }
                    BookCheck();
                    canPress = 0.0f;
                }
                if (Keyboard.current.dKey.wasPressedThisFrame)
                {
                    /*if (currentLevel > 0) { currentLevel--; }
                    else { currentLevel = 1; }*/
                    if (currentLevel == 1) { currentLevel = 0; }
                    else { currentLevel = 1; }
                    BookCheck();
                    canPress = 0.0f;
                }
            }
        }
    }

    /// <summary>
    /// checks which book should be displayed next
    /// </summary>
    public void BookCheck()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].GetComponent<Level_Controller>().ResetAllTriggers();
        }
        for (int i = 0; i < levels.Length; i++)
        {
            if (i != currentLevel) { levels[i].GetComponent<Level_Controller>().BookUnselected(); }
            if (i == currentLevel) { levels[i].GetComponent<Level_Controller>().BookSelected(); }
        }
    }

    /// <summary>
    /// navigates between the cameras only if the player has entered the menu first (isInCam == true)
    /// </summary>
    public void NavigateMenu()
    {   
        if (isInCam && canMove == true)
        {
            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                if (currentCamera == 2)
                {
                    currentCamera = 3;
                    IndexChange(currentCamera);
                }
                else if (currentCamera == 1) { currentCamera = 2; }
                IndexChange(currentCamera);
            }
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                if (currentCamera == 3)
                {
                    currentCamera = 2;
                    IndexChange(currentCamera);
                }
                else if (currentCamera == 2)
                {
                    currentCamera = 1;
                    IndexChange(currentCamera);
                }
            }
        }
    }

    IEnumerator BackToLevelMenu()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i].GetComponent<Level_Controller>().active) { StartCoroutine(levels[i].GetComponent<Level_Controller>().BookReturn()); }
        }
        yield return new WaitForSeconds(2.0f);
        currentCamera = 4;
        IndexChange(currentCamera);
    }

    /// <summary>
    /// controls which camera is active, value (camera) is given through menuIndexValue (through other functions)
    /// </summary>
    /// <param name="menuIndexValue"></param>
    public void IndexChange(int menuIndexValue)
    {
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i].Priority = 1;
            cams[menuIndexValue].Priority = 10;
        }
        for (int i = 0; i < writtenButtons.Length; i++)
        {
            if (menuIndexValue == 1) { writtenButtons[i].interactable = true; }
            else { writtenButtons[i].interactable = false; }
        }
        writtenButtons[0].Select();
    }

    /// <summary>
    /// gets called in Main_Character_Controller, enters the menu and sets camera to first menu camera
    /// </summary>
    public void GoIntoMenu()
    {
        Debug.Log("Into Menu.");
        isInCam = true;
        currentCamera = 2;
        IndexChange(currentCamera);

        Main_Camera_Controller.instance.ChangeFollowStatus(false);
    }

    /// <summary>
    /// Goes into level camera and leaves player in cam mode (can't move)
    /// </summary>
    public void GoIntoLevelMenu()
    {
        Debug.Log("Into Level Menu.");
        currentLevel = 0;
        isInCam = true;
        currentCamera = 4;
        BookCheck();
        canPress = 0.0f;
        IndexChange(currentCamera);

        Main_Camera_Controller.instance.ChangeFollowStatus(false);
    }

    public void OnAction_Button()
    {
        if (isInCam && currentCamera == 4 && canPress > 1.0f)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                if (i == currentLevel)
                {
                    StartCoroutine(levels[i].GetComponent<Level_Controller>().BookDisplay());
                }
                currentCamera = 5;
                LeanTween.delayedCall(2.0f, () => IndexChange(currentCamera));
            }
        }
    }

    public void CanMove()
    {
        canMove = true;
    }

    public void CantMove()
    {
        canMove = false;
    }
}
