using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class PhysicalMenu : MonoBehaviour
{
    public CinemachineVirtualCamera playerCam;
    public CinemachineVirtualCamera menuCam;
    private void Start()
    {
        GoBackToPlayerCam();
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            GoBackToPlayerCam();
        }
    }

    public void GoBackToPlayerCam()
    {
        menuCam.Priority = playerCam.Priority - 1;
        Main_Character_Controller.instance.canRotate = true;
        Main_Character_Controller.instance.canMove = true;
    }

    public void ChangeCamera()
    {
        Debug.Log("hola2");
        if (menuCam.Priority < playerCam.Priority)
            menuCam.Priority = playerCam.Priority + 1;

        Main_Character_Controller.instance.canMove = false;
        Main_Character_Controller.instance.canRotate = false;
    }
}
