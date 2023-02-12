using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InGame_Menu_Controller : MonoBehaviour
{
    public CinemachineVirtualCamera[] cams; //different cameras to choose from
    public Button[] writtenButtons; //buttons used in the book

    int currentCamera; //current camera being used
    bool isInCam; //true if player is currently using any of the menu cameras

    private void Start()
    {
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
            GoBackToPlayerCam();
        }

        NavigateMenu();
    }

    /// <summary>
    /// gets camera back to player view
    /// </summary>
    public void GoBackToPlayerCam()
    {
        if (currentCamera != 0)
        {            
            isInCam = false;
            currentCamera = 0;
            IndexChange(currentCamera); //this is what changes the camera
            for (int i = 0; i < writtenButtons.Length; i++) //disables button interactability
            {
                writtenButtons[i].interactable = false;
            }

            if (Main_Camera_Controller.instance != null) 
            {
                Main_Camera_Controller.instance.ChangeFollowStatus(true);
            }
        }
    }

    /// <summary>
    /// navigates between the cameras only if the player has entered the menu first (isInCam == true)
    /// </summary>
    public void NavigateMenu()
    {   
        if (isInCam)
        {
            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                if (currentCamera == 2)
                {
                    currentCamera = 3;
                    IndexChange(currentCamera);
                }
                else if (currentCamera == 1)
                    currentCamera = 2;
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
            if (menuIndexValue == 1)
                writtenButtons[i].interactable = true;
            else
                writtenButtons[i].interactable = false;
        }
        writtenButtons[0].Select();
    }

    /// <summary>
    /// gets called in Main_Character_Controller, enters the menu and sets camera to first menu camera
    /// </summary>
    public void GoIntoMenu()
    {
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
        isInCam = true;
        currentCamera = 4;
        IndexChange(currentCamera);

        Main_Camera_Controller.instance.ChangeFollowStatus(false);
    }
}
