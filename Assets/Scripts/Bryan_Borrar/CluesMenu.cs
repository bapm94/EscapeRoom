using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CluesMenu : MonoBehaviour
{
    GameObject cluesController;
    [SerializeField] letritas _letritas;
    [SerializeField] public GameObject visual;
    private Controlls _controls;
    // Start is called before the first frame update
    void Start()
    {
        _controls = new Controlls();    //variable to keep track of the controlls there are used this time
        _controls.CharacterControl.Enable(); 

        cluesController = transform.GetChild(0).gameObject;
        visual.SetActive(false);
        Main_Interacction_Controller.instance.onXButton -= onXButton;
        Main_Interacction_Controller.instance.onXButton += onXButton;
        Main_Interacction_Controller.instance.onActionButton -= ActionButton;
        Main_Interacction_Controller.instance.onActionButton += ActionButton;
    }

    private void onXButton()
    {
        if (visual.activeSelf && !Main_Character_Controller_v2.instance.canMove)
        {
            visual.SetActive(false);
            Main_Camera_Controller.instance.ChangeFollowStatus(true);
        }
        else if (!visual.activeSelf && Main_Character_Controller_v2.instance.canMove)
        {
            visual.SetActive(true);
            Main_Camera_Controller.instance.ChangeFollowStatus(false);
        }
    }
    private void ActionButton()
    {
        if (visual.activeSelf)
        {
            _letritas.RevealLetter();
        }
    }
    private void Update()
    {
        if (!Main_Character_Controller_v2.instance.canMove && gameObject.activeSelf)
        {
            float pressingButton = _controls.CharacterControl.Action_Button.ReadValue<float>();
            if (pressingButton != 0f)
            {
                if (visual.activeSelf)
                {
                    _letritas.RevealLetter();
                }
            }
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Keyboard.current.cKey.wasPressedThisFrame)
    //    {
    //        if (visual.activeSelf  && !Main_Character_Controller_v2.instance.canMove)
    //        {
    //            visual.SetActive(false);
    //            Main_Camera_Controller.instance.ChangeFollowStatus(true);
    //        }
    //        else if (!visual.activeSelf && Main_Character_Controller_v2.instance.canMove)
    //        {
    //            visual.SetActive(true);
    //            Main_Camera_Controller.instance.ChangeFollowStatus(false);
    //        }
    //    }
    //    if (Keyboard.current.eKey.isPressed && visual.activeSelf)
    //    {
    //        _letritas.RevealLetter();
    //    }
    //}
}
