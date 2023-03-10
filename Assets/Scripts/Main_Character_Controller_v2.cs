using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Main_Character_Controller_v2 : MonoBehaviour
{
    #region Original State Variables
    public Transform spawn { get; set; }
    #endregion

    #region Movement Variables
    [SerializeField] public float turnSpeed = 1;
    [SerializeField] public float walkSpeed = 1;
    float xRotation = 0f;       //Variable that keeps the rotation of the camera.
    private Controlls _controls;    //Acces to the controls through the new input system
    
    public bool canMove {get; set;}
    public bool canRotate { get; set; }


    #endregion

    #region Looking At X Variables
    GameObject percievedGO;
    public GameObject PerceivedGO { get; set; }
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

    public LayerMask ignoreMe;

    public LayerMask collideMe;

    [SerializeField] Camera analizingCam;

    bool isCollidingWithWall;

    public static Main_Character_Controller_v2 instance;

    [SerializeField] GameObject clueCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
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

        analizingCam.gameObject.SetActive(false);

        transform.position = spawn.position; transform.rotation = spawn.rotation;

        LeanTween.reset();
    }

    private void FixedUpdate()
    {
        if (canMove) { Movement(); LookFront(); }
        
        
        if (isAnalizingOject) { Analizing(); }
    }
    private void Update()
    {
        if (canRotate) { Rotation(); } //Only rotates when the camera is attached to the character
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
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 5f, ~ignoreMe))
            {
                if (hit.collider.gameObject.layer == 6 && hit.collider.tag == "000")
                {
                    isLookingSomething = true;
                    percievedGO = hit.collider.gameObject;
                    if (percievedGO.layer == 6)
                    {
                        percievedGO.layer = 8;
                        ChangeSubmeshesLayer(percievedGO, 8);
                    }
                    percievedGO.GetComponent<Prop>().OutlineColor();
                }
            }
            else 
            {
                isLookingSomething = false; 
                if (percievedGO != null) { percievedGO.GetComponent<Prop>().hasDone = false; } 
                percievedGO = null; 
            }
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
    //private void newOnActionButton()
    //{
    //    Debug.Log(percievedGO.name);
    //}
    private void OnAction_Button()
    {
        if (LookFront() && canMove)
        {
            Main_Interacction_Controller.instance.ActionButton();  //If the action button is pressed while moving and its seeing something then it ask the iteraci?n manager to send the perfome the action.
        }
        else if (isAnalizingOject) { Main_Interacction_Controller.instance.YButton(); }
        //if (clueCanvas != null && !canMove)
        //{
        //    if (clueCanvas.activeSelf)
        //    {
        //        Main_Interacction_Controller.instance.ActionButton();
        //    }
        //}
    }

    private void OnBack_Button()
    {
        Main_Interacction_Controller.instance.BackButton();
        if (isAnalizingOject && !Dialogue_System_Controller.instance.dialogueOnGoing) { StopAnalizing(); }
    }

    private void OnMenu_Button()
    {
        if (isAnalizingOject && !Dialogue_System_Controller.instance.dialogueOnGoing) { StopAnalizing(); }
        else if (SceneManager.GetActiveScene().name == "Alice_Kitchen_Scene" && InGame_Menu_Controller.instance.currentCamera ==0 && !Dialogue_System_Controller.instance.dialogueOnGoing && !inventoryTemp.gameObject.activeSelf)
        {
            
            if (InGameMenu.instance.baseMenu.activeSelf)
            {
                Debug.Log("hola");
                InGameMenu.instance.ChangeBaseMenuStatus(false);
            }
            else if (!InGameMenu.instance.baseMenu.activeSelf && !InGameMenu.instance.settingsMenu.activeSelf)
            {
                InGameMenu.instance.ChangeBaseMenuStatus(true);
            }
        }
    }
    private void OnX_Button()
    {
        //Debug.Log("X");
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
        if (SceneManager.GetActiveScene().name == "Alice_Kitchen_Scene")
        {
            Main_Interacction_Controller.instance.XButton();
        }
    }

    private void OnY_Button()
    {
        Main_Interacction_Controller.instance.YButton();
        if (!Dialogue_System_Controller.instance.dialogueOnGoing && SceneManager.GetActiveScene().name != "LobbyScene")
        {

            if (inventoryTemp != null && !inventoryTemp.gameObject.activeSelf && canMove)  //If not already open, opens te inventory
            {
                LeanTween.cancel(inventoryTemp._parentRoot);
                Camera.main.GetComponent<Volume>().enabled = true;
                Main_Camera_Controller.instance.ChangeFollowStatus(false);
                inventoryTemp._parentRoot.SetActive(true);
                inventoryTemp.openByPlayer = true;                
                inventoryTemp.firstSelect.GetComponent<Button>().Select();
                inventoryTemp.InitialAnimation();
                
            }
            else if (inventoryTemp != null && inventoryTemp.gameObject.activeSelf && inventoryTemp.openByPlayer && !canMove)
            {
                inventoryTemp.openByPlayer = false;
                Camera.main.GetComponent<Volume>().enabled = false;
                Main_Camera_Controller.instance.ChangeFollowStatus(true);
                inventoryTemp.CloseInventory();
            }
            else if (inventoryTemp != null && Camera.main.GetComponent<Volume>().isActiveAndEnabled && !inventoryTemp.gameObject.activeSelf)
            {
                inventoryTemp.openByPlayer = false;
                Camera.main.GetComponent<Volume>().enabled = false;
                Main_Camera_Controller.instance.ChangeFollowStatus(true);
            }
        }
        
    }

    #endregion

    #region Character Movement

    private void Movement()
    {
        Vector2 movement = _controls.CharacterControl.Walk.ReadValue<Vector2>() * Time.deltaTime; //The value of the x and y axis are get. Multiply by speed and delta time to keep consistency.
        //Vector2 moveeee = movement.normalized;
        Vector3 move = transform.right * movement.x * Time.deltaTime * walkSpeed *10  + transform.forward * movement.y * Time.deltaTime * walkSpeed *10; //New variable that stores the advance in position
        var newPos = transform.position + move; // The movement done at the end of calculations
        var wallDetection = (newPos - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.down * transform.position.y * 3 / 4, wallDetection , out hit, GetComponent<CapsuleCollider>().radius + 0.05f, collideMe) /*&& isCollidingWithWall*/)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Bob_Controller>().canBob = false;
            gameObject.GetComponent<Bob_Controller>().HeadBob();
        }
        else
        {
            gameObject.GetComponent<Bob_Controller>().canBob = true;
            transform.position = newPos;
            if (gameObject.GetComponent<Bob_Controller>() != null) { gameObject.GetComponent<Bob_Controller>().HeadBob(); }
        }
    }
    private void Rotation()
    {
        if (Main_Camera_Controller.instance.isFollowingCharacter)
        {
            Vector2 rotation1 = _controls.CharacterControl.Cam_Rotation.ReadValue<Vector2>() ; //Same sht but with rotation
            Vector2 rotation = rotation1 * turnSpeed * Time.deltaTime * 3;
            transform.Rotate(Vector3.up * rotation.x );

            xRotation -= rotation.y ;
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
        GOtoAnalize.transform.localScale = Vector3.one;
        GOtoAnalize.transform.localEulerAngles = Vector3.zero;
    }

    public void StartAnalizing(GameObject GOtoAnalize, Vector3 localScale, Vector3 localEulerAngle)
    {
        analizingCam.gameObject.SetActive(true);
        canMove = false; canRotate = false; isAnalizingOject = true;
        analizableObject = GOtoAnalize;
        analizer.PositioningItem(GOtoAnalize);
        GOtoAnalize.transform.localScale = localScale;
        GOtoAnalize.transform.localEulerAngles = localEulerAngle;

        //GOtoAnalize.TryGetComponent<Prop_Controller>(out Prop_Controller controller);
        //if (controller != null)
        //{
        //    GOtoAnalize.transform.localScale = Vector3.one * controller.AnalyzingScale;
        //    GOtoAnalize.transform.localEulerAngles = controller.AnalyzingRotation;
        //}        
    }


    private void Analizing()
    {
        Vector2 rotations = (_controls.CharacterControl.Walk.ReadValue<Vector2>() * walkSpeed * Time.deltaTime * 20).normalized;
        var upAxis = analizer.analizingSpot.transform.TransformDirection(Vector3.up);
        analizableObject.transform.RotateAround(analizer.analizingSpot.transform.position, upAxis, - Time.deltaTime * rotations.x*100);
        var rigthAxis = analizer.analizingSpot.transform.TransformDirection(Vector3.right);
        analizableObject.transform.RotateAround(analizer.analizingSpot.transform.position, rigthAxis, Time.deltaTime * rotations.y * 100);
    }
    public void StopAnalizing()
    {
        analizingCam.gameObject.SetActive(false);
        analizer.ReturnItem();        
        Main_Camera_Controller.instance.ChangeFollowStatus(true);
        isAnalizingOject = false;        
    }

    #endregion
}
