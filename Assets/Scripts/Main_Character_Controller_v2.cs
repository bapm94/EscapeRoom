using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
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
    GameObject percievedGO;
    GameObject PerceivedGO { get => percievedGO;  }
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
    public bool isAnalizingOject;

    #endregion


    
    #region Temporal Inventory
    [SerializeField] Inventory_Temp inventoryTemp;
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
        if (canMove)
        {            
            if (percievedGO != null)
            {
                percievedGO.layer = 6;

                ChangeSubmeshesLayer(percievedGO, 6);

            }
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 5f))
            {
                if (hit.collider.gameObject.layer == 6)
                {
                    isLookingSomething = true;
                    percievedGO = hit.collider.gameObject;
                    if (percievedGO.layer == 6)
                    {
                        percievedGO.layer = 8;
                        ChangeSubmeshesLayer(percievedGO, 8);
                    }
                }


            }
            else { isLookingSomething = false; percievedGO = null; }
        }
     
        return isLookingSomething;
    }

    public void ChangeSubmeshesLayer(GameObject percievedGO, int LayerTo)
    {
        if (percievedGO.transform.childCount > 0)
        {
            if (percievedGO.transform.GetChild(0).childCount > 1)
            {
                for (int child = 0; child < percievedGO.transform.GetChild(0).childCount; child++)
                {
                    MeshRenderer mesh = percievedGO.transform.GetChild(0).GetChild(child).GetComponent<MeshRenderer>();
                    if (mesh != null)
                    {
                        percievedGO.transform.GetChild(0).GetChild(child).gameObject.layer = LayerTo;
                    }
                }
            }
            else if (percievedGO.transform.GetChild(0).childCount == 1)
            {
                MeshRenderer mesh = percievedGO.transform.GetChild(0).GetComponentInChildren<MeshRenderer>();
                if (mesh != null)
                {
                    mesh.gameObject.layer = LayerTo;
                }
            }
        }
    }

    #region Player Actions

    private void OnAction_Button()
    {
        if (LookFront() && canMove)
        {
            if (percievedGO.GetComponent<In_Game_Tool>() != null)
            {
                In_Game_Tool range = percievedGO.GetComponent<In_Game_Tool>();
                if (range.hasDialogue == true) 
                {
                    range.hasDialogue = false;
                    Dialogue_System_Controller.instance.GetDialogueInfo(range.dialogueBeginning, range.dialogueEnd);
                }
            }

            percievedGO.TryGetComponent<Prop_Controller>(out Prop_Controller controller);
            if (controller != null) { controller.ActionButtonOnIt(); } 
            
            percievedGO.TryGetComponent<Restoring_Puzzle>(out Restoring_Puzzle controller2);
            if (controller2 != null) { controller2.ActionButtonOnIt(); }
            








            #region Old TagSystem
            //if (percievedGO.tag == "MenuChair")
            //{
            //    if (physicalMenu != null) { physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoMenu(); }
            //    percievedGO.layer = 6;
            //}
            //if (percievedGO.tag == "MenuLibrary")
            //{
            //    if (physicalMenu != null) { physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoLevelMenu(); }
            //    percievedGO.layer = 6;
            //}
            //if (percievedGO.tag == "Analizable")
            //{
            //    StartAnalizing(percievedGO);
            //}
            //if (percievedGO.tag == "Tool")
            //{
            //    percievedGO.TryGetComponent<Prop_Controller>(out Prop_Controller propController);
            //    if (propController != null)
            //    {
            //        percievedGO.transform.GetComponent<Prop_Controller>().PutInTempInventory();
            //    }
            //    else
            //    {
            //        percievedGO.transform.parent.GetComponent<Prop_Controller>().PutInTempInventory();
            //    }

            //    percievedGO.layer = 6;
            //}
            #endregion

        }
    }

    private void OnBack_Button()
    {
        if (isAnalizingOject /*&& !Dialogue_System_Controller.instance.dialogueOnGoing*/) { StopAnalizing(); }
    }

    private void OnX_Button()
    {
        Debug.Log("X");
        if (isAnalizingOject)
        {
            analizableObject.TryGetComponent<Prop_Controller>(out Prop_Controller controller);
            if (controller != null)
            {
                analizableObject.transform.localEulerAngles = controller.AnalyzingRotation;
            }
            else
            {
                analizableObject.transform.localEulerAngles = (Vector3.zero);
            }
        }
    }

    private void OnY_Button()
    {
        if (inventoryTemp != null && !inventoryTemp.gameObject.activeSelf)  //If not already open, opens te inventory
        {
            Camera.main.GetComponent<Volume>().enabled = true;
            Main_Camera_Controller.instance.ChangeFollowStatus(false);
            inventoryTemp.openByPlayer = true;
            inventoryTemp._parentRoot.SetActive(true);
            //inventoryTemp.gameObject.transform.GetChild(0).GetComponent<Button>().Select();
        }
        else if (inventoryTemp != null && inventoryTemp.gameObject.activeSelf)
        {
            Camera.main.GetComponent<Volume>().enabled = false;
            Main_Camera_Controller.instance.ChangeFollowStatus(true);
            inventoryTemp.CloseInventory();
        }
    }

    #endregion

    #region Character Movement

    private void Movement()
    {
        Vector2 movement = _controls.CharacterControl.Walk.ReadValue<Vector2>() * Time.deltaTime; //The value of the x and y axis are get. Multiply by speed and delta time to keep consistency.
        Vector2 moveeee = movement.normalized;
        Vector3 move = transform.right * moveeee.x * Time.deltaTime * walkSpeed  + transform.forward * moveeee.y * Time.deltaTime * walkSpeed ; //New variable that stores the advance in position
        var newPos = transform.position + move; // The movement done at the end of calculations
        var wallDetection = (newPos - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.down * transform.position.y * 3 / 4, wallDetection , out hit, GetComponent<CapsuleCollider>().radius + 0.4f, 8) /*&& isCollidingWithWall*/)
        {
            
        }
        else
        {
            transform.position = newPos;
        }
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
        GOtoAnalize.TryGetComponent<Prop_Controller>(out Prop_Controller controller);
        if (controller != null)
        {
            GOtoAnalize.transform.localScale = Vector3.one * controller.AnalyzingScale;
            GOtoAnalize.transform.localEulerAngles = controller.AnalyzingRotation;
        }
        
    }
    private void Analizing()
    {
        Vector2 rotations = (_controls.CharacterControl.Walk.ReadValue<Vector2>() * walkSpeed * Time.deltaTime * 20).normalized;
        var upAxis = analizer.analizingSpot.transform.TransformDirection(Vector3.up);
        analizableObject.transform.RotateAround(analizer.analizingSpot.transform.position, upAxis, - Time.deltaTime * rotations.x*100);
        var rigthAxis = analizer.analizingSpot.transform.TransformDirection(Vector3.right);
        analizableObject.transform.RotateAround(analizer.analizingSpot.transform.position, rigthAxis, Time.deltaTime * rotations.y * 100);
    }
    private void StopAnalizing()
    {
        analizer.ReturnItem();        
        Main_Camera_Controller.instance.ChangeFollowStatus(true);
        isAnalizingOject = false;
        
    }

    #endregion
}
