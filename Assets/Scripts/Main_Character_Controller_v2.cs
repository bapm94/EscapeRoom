using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Character_Controller_v2 : MonoBehaviour
{
    #region Original State Variables
    public Transform spawn { get; set; }
    #endregion

    #region Movement Variables
    [SerializeField] float turnSpeed = 1;
    [SerializeField] float walkSpeed = 1;
    float xRotation = 0f;       //Variable that keeps the rotation of the camera.
    private Controlls _controls;    //Acces to the controls through the new input system
    GameObject mainCamera;
    public bool canMove {get; set;}
    public bool canRotate { get; set; }


    #endregion

    #region Looking At X Variables
    GameObject perceivedGO;
    GameObject PerceivedGO { get => perceivedGO;  }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        canMove = true; canRotate = true;
        spawn = transform.parent.GetChild(1);
        mainCamera = transform.GetChild(0).gameObject;

        transform.position = spawn.position; transform.rotation = spawn.rotation; 
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) { Movement(); }
        if (canRotate) { Rotation(); } //Only rotates when the camera is attached to the character
    }


    public bool LookFront()
    {
        bool isLookingSomething = false;

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 5f))
        {
            isLookingSomething = true;
            perceivedGO = hit.collider.gameObject;
        }
        return isLookingSomething;
    }

    #region Character Movement

    private void Movement()
    {
        Vector2 movement = _controls.CharacterControl.Walk.ReadValue<Vector2>() * walkSpeed * Time.deltaTime; //The value of the x and y axis are get. Multiply by speed and delta time to keep consistency.
        Vector3 move = transform.right * movement.x * Time.deltaTime * 400 + transform.forward * movement.y * Time.deltaTime * 400; //New variable that stores the advance in position
        var newPos = transform.position + move; // The movement done at the end of calculations
        RaycastHit hit;
        if (!Physics.Raycast(transform.position + Vector3.down * transform.position.y * 3 / 4, (newPos - transform.position), out hit, GetComponent<CapsuleCollider>().radius + 0.4f))
        {
            transform.position = newPos;
        }       
        //Debug.DrawRay(transform.position + Vector3.down * transform.position.y * 3 / 4, (newPos - transform.position), Color.green, 1f);
    }
    private void Rotation()
    {
        if (Main_Camera_Controller.instance.isFollowingCharacter)
        {
            Vector2 rotation = _controls.CharacterControl.Cam_Rotation.ReadValue<Vector2>() * turnSpeed * Time.deltaTime * 10; //Same sht but with rotation
            ;
            transform.Rotate(Vector3.up * rotation.x * Time.deltaTime * 400);

            xRotation -= rotation.y * Time.deltaTime * 400;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Limit to the rotation so the player can`t "break" his own neck and see backwards
            mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); //In this case what we rotate is the camera and not the whole character

        }
    }

    #endregion
}
