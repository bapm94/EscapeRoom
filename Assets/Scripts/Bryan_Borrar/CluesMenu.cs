using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CluesMenu : MonoBehaviour
{
    GameObject cluesController;
    [SerializeField] letritas _letritas;
    [SerializeField] public GameObject visual;
    // Start is called before the first frame update
    void Start()
    {
        cluesController = transform.GetChild(0).gameObject;
        visual.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            if (visual.activeSelf)
            {
                visual.SetActive(false);
                Main_Camera_Controller.instance.ChangeFollowStatus(true);
            }
            else
            {
                visual.SetActive(true);
                Main_Camera_Controller.instance.ChangeFollowStatus(false);
            }
        }
        if (Keyboard.current.eKey.isPressed && visual.activeSelf)
        {
            _letritas.RevealLetter();
        }
    }
}
