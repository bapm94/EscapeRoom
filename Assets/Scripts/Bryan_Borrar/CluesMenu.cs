using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CluesMenu : MonoBehaviour
{
    GameObject cluesController;
    [SerializeField] letritas _letritas;
    // Start is called before the first frame update
    void Start()
    {
        cluesController = transform.GetChild(0).gameObject;
        cluesController.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            if (cluesController.activeSelf)
            {
                cluesController.SetActive(false);
                Main_Camera_Controller.instance.ChangeFollowStatus(true);
            }
            else
            {
                cluesController.SetActive(true);
                Main_Camera_Controller.instance.ChangeFollowStatus(false);
            }
        }
        if (Keyboard.current.eKey.isPressed && cluesController.activeSelf)
        {
            _letritas.RevealLetter();
        }
    }
}
