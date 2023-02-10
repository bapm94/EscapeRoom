using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Main_Character_Controller : MonoBehaviour
{
    [SerializeField] float turnSpeed = 1;
    [SerializeField] float walkSpeed = 1;
    

    float xRotation = 0f;       //Variable that keeps the rotation of the camera.
    private Controlls _controls;    //Acces to the controls through the new input system
    public GameObject mainCamera;
    public GameObject physicalMenu;


    public bool isLookingAtChair = false;
    public bool isLookingAtLibrary = false;
    public bool canMove = true;
    public bool canRotate = true;
    public bool isAnalizingOject = false;
    public Vector3 originalRespawn;

    private GameObject analizableObject;
    private Vector3 analizableOriginalRotation;
    private Vector3 analizableOriginalPosition;
    private Vector3 analizableOriginalScale;
    private Color defaultColor;
    private bool defaultColorTaken = false;
    Vector2 analizableObjectRotation = Vector2.zero;

    Main_Character_Item_Analizer analizer;
    public static Main_Character_Controller instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            Main_Character_Controller.instance = this;
        else
            Destroy(this);

        ResetAll();
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove) { Movement(); }
        if (canRotate && Main_Camera_Controller.instance.isFollowingCharacter) { Rotation(); } //Only rotates when the camera is attached to the character

        if (isAnalizingOject) { Analizing();    }

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 15f))
        {
            if (hit.collider.gameObject.tag != "Selectable" && defaultColorTaken )
            {
                analizableObject.GetComponent<MeshRenderer>().material.color = defaultColor;
                
               
                analizableObject = null;
                defaultColorTaken = false;
            }
            else if (hit.collider.gameObject.tag == "Selectable")
            {                
                analizableObject = hit.collider.gameObject;
                if (!defaultColorTaken) 
                {
                    analizableOriginalPosition = analizableObject.transform.position;
                    analizableOriginalRotation = analizableObject.transform.rotation.eulerAngles;
                    defaultColorTaken = true;
                    defaultColor = analizableObject.GetComponent<MeshRenderer>().material.color; 
                }
                analizableObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }

            if (hit.collider.gameObject.tag == "MenuChair")
            {
                isLookingAtChair = true;
                if (Keyboard.current.fKey.wasPressedThisFrame)
                {
                    Dialogue_System_Controller.instance.GetDialogueInfo(0, 3);
                }
            }
            else if (hit.collider.gameObject.tag != "MenuChair")
                isLookingAtChair = false;

            if (hit.collider.gameObject.tag == "MenuLibrary")
                isLookingAtLibrary = true;
            else if (hit.collider.gameObject.tag != "MenuLibrary")
                isLookingAtLibrary = false;

            /*bug? como solo se hace false el bool cuando golpea con algo que no tiene el tag, al mirar alrededor de
            la sala, como las paredes etc no tienen collider, darle al botón de acción en el aire hace que
            funcione igualmente*/

            //Debug.Log("Estas mirando a " + hit.collider.gameObject.name +" y tiene transformada original igual a " + analizableOriginalRotation);
        }
        if (!Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 15f) && defaultColorTaken )
        {            
            analizableObject.GetComponent<MeshRenderer>().material.color = defaultColor;
            analizableObject.transform.eulerAngles = analizableOriginalRotation; 
            analizableObject = null;
            defaultColorTaken = false;
            StopAnalizing();
        }

    }



    #region Character Movement


    private void Movement()
    {
        Vector2 movement = _controls.CharacterControl.Walk.ReadValue<Vector2>() * walkSpeed * Time.deltaTime; //The value of the x and y axis are get. Multiply by speed and delta time to keep consistency.
        Vector3 move = transform.right * movement.x * Time.deltaTime * 400 + transform.forward * movement.y * Time.deltaTime * 400; //New variable that stores the advance in position

        var newPos = transform.position + move; // The movement done at the end of calculations
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.down * transform.position.y *3/4, (newPos - transform.position), out hit, GetComponent<CapsuleCollider>().radius + 0.4f))
        {
            
        }
        else
        {
            transform.position = newPos;
            //Rigidbody rb = GetComponent<Rigidbody>();
            //rb.MovePosition(newPos);
        }
        Debug.DrawRay(transform.position + Vector3.down * transform.position.y *3/4, (newPos - transform.position), Color.green, 1f);

    }
    private void Rotation()
    {
        Vector2 rotation  = _controls.CharacterControl.Cam_Rotation.ReadValue<Vector2>() * turnSpeed * Time.deltaTime * 10; //Same sht but with rotation
        ;
        transform.Rotate(Vector3.up * rotation.x * Time.deltaTime*400 );

        xRotation -= rotation.y * Time.deltaTime*400; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Limit to the rotation so the player can`t "break" his own neck and see backwards
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); //In this case what we rotate is the camera and not the whole character
       
    }

    #endregion

    #region Character Actions

    private void OnAction_Button() //Funtion called on players action button press
    {
        if (analizableObject == null)
        {
            Debug.Log("has apretado el boton de acción");
        }
        else
        {
            
            if (isAnalizingOject)
            {
                StopAnalizing();
            }
            else
            {
                StartAnalizing(analizableObject);
            }
            

        }

        if (isLookingAtChair)
            physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoMenu();
        if (isLookingAtLibrary)
            physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoLevelMenu();
    }


    #endregion 
    public void ResetAll()  // Meant to reset all the posible variables at the start.
    {
        analizer = gameObject.GetComponent<Main_Character_Item_Analizer>();
        _controls = new Controlls();    //variable to keep track of the controlls there are used this time
        _controls.CharacterControl.Enable();
        transform.position = new Vector3 (originalRespawn.x, originalRespawn.y, originalRespawn.z);
    }

    #region Analizing Functions

    public void StartAnalizing(GameObject GOtoAnalize)
    {
        canMove = false; canRotate = false; isAnalizingOject = true;
        analizableObject = GOtoAnalize;
        analizer.PositioningItem(GOtoAnalize);
        //Debug.Log("Rotacion del personaje : " + transform.rotation + "Rotación de "+ analizableObject.name +" : " + analizableObject.transform.rotation);

    }
    private void Analizing()
    {
        Vector2 rotations = _controls.CharacterControl.Walk.ReadValue<Vector2>() * walkSpeed * Time.deltaTime * 20;
        analizableObject.transform.Rotate(new Vector3 (rotations.y,  -1*rotations.x, 0), Space.World);
        //analizableObject.transform.RotateAround(analizableObject.transform.position, Vector3.up , rotations.x);
        //analizableObject.transform.RotateAround(analizableObject.transform.position, transform.localEulerAngles, rotations.y);
        //new Vector3(transform.localEulerAngles.x, 0, 0)
    }
    private void StopAnalizing()
    {
        analizer.ReturnItem();
        canMove = true; canRotate = true; isAnalizingOject = false ;

    }

    #endregion


}
