using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    
    public bool canMove {get; set;}
    public bool canRotate { get; set; }


    #endregion

    #region Looking At X Variables
    GameObject perceivedGO;
    GameObject PerceivedGO { get => perceivedGO;  }
    #endregion

    #region Camera Variables

    GameObject mainCamera;
    public GameObject physicalMenu;

    #endregion

    #region Analizable Object Variables

    private GameObject analizableObject;
    private Vector3 analizableOriginalRotation;
    private Vector3 analizableOriginalPosition;
    private Vector3 analizableOriginalScale;
    private Color defaultColor;
    private bool defaultColorTaken = false;
    Vector2 analizableObjectRotation = Vector2.zero;
    Main_Character_Item_Analizer analizer;
    bool isAnalizingOject;

    #endregion


    bool isCollidingWithWall;

    public static Main_Character_Controller_v2 instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Main_Character_Controller_v2.instance == null)
        {
            Main_Character_Controller_v2.instance = this;
        }
        else
        {
            Destroy(this);
        }
        analizer = gameObject.GetComponent<Main_Character_Item_Analizer>();
        canMove = true; canRotate = true;
        spawn = transform.parent.GetChild(1);
        mainCamera = transform.GetChild(0).gameObject;
        _controls = new Controlls();    //variable to keep track of the controlls there are used this time
        _controls.CharacterControl.Enable();

        transform.position = spawn.position; transform.rotation = spawn.rotation; 
    }

    // Update is called once per frame
    void Update()
    {
        }
    private void FixedUpdate()
    {
        if (canMove) { Movement(); }
        if (canRotate) { Rotation(); } //Only rotates when the camera is attached to the character
        LookFront();
        if (isAnalizingOject) { Analizing(); }

    }


    public bool LookFront()
    {
        bool isLookingSomething = false;
        if (perceivedGO != null) { perceivedGO.layer = 6; }
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 5f) )
        {
            if (hit.collider.gameObject.layer == 6)
            {
                isLookingSomething = true;
                perceivedGO = hit.collider.gameObject;
                if (perceivedGO.layer == 6)
                {
                    perceivedGO.layer = 8;
                }
            }            
        }
        else { isLookingSomething = false;  perceivedGO = null; }
        return isLookingSomething;
    }

    private void OnAction_Button()
    {
        if (LookFront() && canMove)
        {
            if (perceivedGO.tag == "MenuChair")
            {
                if (physicalMenu != null) { physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoMenu(); }
            }
            if (perceivedGO.tag == "MenuLibrary")
            {
                if (physicalMenu != null) { physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoLevelMenu(); }
            }
            if (perceivedGO.tag == "Analizable")
            {
                StartAnalizing(perceivedGO);
            }
        }
    }

    private void OnBack_Button()
    {
        if (isAnalizingOject) { StopAnalizing(); }
    }

    private void OnX_Button()
    {
        Debug.Log("X");
        if (isAnalizingOject) { analizableObject.transform.localEulerAngles = (Vector3.zero); }
    }

    #region Character Movement

    private void Movement()
    {
        Vector2 movement = _controls.CharacterControl.Walk.ReadValue<Vector2>() * Time.deltaTime; //The value of the x and y axis are get. Multiply by speed and delta time to keep consistency.
        Vector2 moveeee = movement.normalized;
        Vector3 move = transform.right * moveeee.x * Time.deltaTime * walkSpeed  + transform.forward * moveeee.y * Time.deltaTime * walkSpeed ; //New variable that stores the advance in position
        var newPos = transform.position + move; // The movement done at the end of calculations
        var wallDetection = (newPos - transform.position).normalized;
        RaycastHit hit;
        if (!Physics.Raycast(transform.position + Vector3.down * transform.position.y * 3 / 4, wallDetection , out hit, GetComponent<CapsuleCollider>().radius + 0.4f) && !isCollidingWithWall)
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
            transform.Rotate(Vector3.up * rotation.x * Time.deltaTime * 400);

            xRotation -= rotation.y * Time.deltaTime * 400;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Limit to the rotation so the player can`t "break" his own neck and see backwards
            mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); //In this case what we rotate is the camera and not the whole character

        }
    }

    #endregion

    #region Analizing Functions

    public void StartAnalizing(GameObject GOtoAnalize)
    {
        canMove = false; canRotate = false; isAnalizingOject = true;
        analizableObject = GOtoAnalize;
        analizer.PositioningItem(GOtoAnalize);
       
    }
    private void Analizing()
    {
        Vector2 rotations = (_controls.CharacterControl.Walk.ReadValue<Vector2>() * walkSpeed * Time.deltaTime * 20).normalized;
        
        //analizableObject.transform.Rotate(new Vector3(rotations.y , -1 * rotations.x, 0), Space.World);
        analizableObject.transform.RotateAround(analizer.analizingSpot.transform.position, Vector3.up, - Time.deltaTime * rotations.x*100);
        analizableObject.transform.RotateAround(analizer.analizingSpot.transform.position, Vector3.forward, -Time.deltaTime * rotations.y * 100);

    }
    private void StopAnalizing()
    {
        analizer.ReturnItem();
        canMove = true; canRotate = true; isAnalizingOject = false;

    }

    #endregion
}
