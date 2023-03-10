using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class RotationOnDrag : MonoBehaviour
{
    private Quaternion originalRotation;
    private float startAngle = 0;
    [SerializeField] int dialVictoryValue;
    public bool victory  {get; set;}
    [SerializeField] PropCodePuzzle puzzleSolver;
    private Controlls _controls;
    [SerializeField] bool leftDial;

    //[SerializeField] Vector3 rotationAxis = new Vector3 (0,0,1);

    // Start is called before the first frame update
    void Start()
    {
        victory = false;
        originalRotation = gameObject.transform.localRotation;
        if (dialVictoryValue < 0)
        {
            dialVictoryValue = 360 + dialVictoryValue;
        }
        _controls = new Controlls();    //variable to keep track of the controlls there are used this time
        _controls.CharacterControl.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        if (InGame_Menu_Controller.instance.currentCamera == 1)
        {
           DialWithControls(leftDial);
        }
    }
    private void OnMouseDrag()
    {
        
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vector = Input.mousePosition - screenPos;
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.AngleAxis(angle - startAngle, transform.forward);
        newRotation.y = 0; //see comment from above 
        newRotation.eulerAngles = new Vector3(0, 0, newRotation.eulerAngles.z);
        transform.localRotation = originalRotation * newRotation;
        

        if (dialVictoryValue - 10 <= transform.localEulerAngles.z && transform.localEulerAngles.z < dialVictoryValue + 10)
        {
            victory = true;
            
        }
        else { victory = false; }
        
    }
    

    public void ShowState()
    {
        //Debug.Log(victory);
    }
    private void OnMouseUp()
    {
        if (puzzleSolver != null)
        {
            puzzleSolver.CheckForVictory();
        }
    }


    void DialWithControls(bool x)
    {
        Vector2 rotation1 = _controls.CharacterControl.Walk.ReadValue<Vector2>() * Time.deltaTime; //Same sht but with rotation
        Vector2 rotation2 = _controls.CharacterControl.Cam_Rotation.ReadValue<Vector2>() * Time.deltaTime;
                                                                                                   //  Vector2 movement = _controls.CharacterControl.Walk.ReadValue<Vector2>() * Time.deltaTime;
                                                                                                   // Vector2 rotation1 = _controls.CharacterControl.Cam_Rotation.ReadValue<Vector2>();
        if (x)
        {            
            Vector2 rotation = rotation1.normalized * 1;
            transform.Rotate(Vector3.forward * rotation.x);
        }
        else if (!x && rotation1 == Vector2.zero)
        {
            Vector2 rotation = rotation2.normalized * 1;
            transform.Rotate(Vector3.forward * rotation.x);
        }


        if (rotation1 == rotation2)
        {
            tryToResolve();

        }

        void tryToResolve()
        {
            if (dialVictoryValue - 10 <= transform.localEulerAngles.z && transform.localEulerAngles.z < dialVictoryValue + 10)
            {
                victory = true;

            }
            else { victory = false; }

            if (puzzleSolver != null)
            {
                puzzleSolver.CheckForVictory();
            }
        }
    }
}
