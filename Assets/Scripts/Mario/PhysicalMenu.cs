using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class PhysicalMenu : MonoBehaviour
{
    //public CinemachineVirtualCamera playerCam;
    //public CinemachineVirtualCamera menuCam;
    public CinemachineVirtualCamera[] cams;

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
        cams[1].Priority = cams[0].Priority - 1;
        Main_Character_Controller.instance.canRotate = true;
        Main_Character_Controller.instance.canMove = true;
    }

    public void ChangeCamera()
    {
        Debug.Log("hola2");
        if (cams[1].Priority < cams[0].Priority)
            cams[1].Priority = cams[0].Priority + 1;

        Main_Character_Controller.instance.canMove = false;
        Main_Character_Controller.instance.canRotate = false;
    }
}
