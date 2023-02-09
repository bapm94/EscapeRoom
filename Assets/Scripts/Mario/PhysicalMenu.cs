using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PhysicalMenu : MonoBehaviour
{
    //public CinemachineVirtualCamera playerCam;
    //public CinemachineVirtualCamera menuCam;
    public CinemachineVirtualCamera[] cams;
    public Button[] writtenButtons;
    int currentCamera;
    bool isInCam;

    private void Start()
    {
        for (int i = 0; i < writtenButtons.Length; i++)
        {
            writtenButtons[i].interactable = false;
        }
        currentCamera = 0;
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

    public void GoBackToPlayerCam()
    {
        isInCam = false;
        currentCamera = 0;
        IndexChange(currentCamera);
        for (int i = 0; i < writtenButtons.Length; i++)
        {
            writtenButtons[i].interactable = false;
        }

        if (Main_Character_Controller.instance != null)
        {
            Main_Character_Controller.instance.canRotate = true;
            Main_Character_Controller.instance.canMove = true;
        }
    }

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

    public void GoIntoMenu()
    {
        isInCam = true;
        currentCamera = 2;
        IndexChange(currentCamera);

        Main_Character_Controller.instance.canMove = false;
        Main_Character_Controller.instance.canRotate = false;
    }
}
