using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Prop_Controller : MonoBehaviour
{
    [SerializeField] float spriteScale = 0.5f;
    [SerializeField] float analyzingScale = 1f;
    [SerializeField] Vector3 analyzingRotation;
    //[SerializeField] bool isTool;

    public float AnalyzingScale { get => analyzingScale; }
    public Vector3 AnalyzingRotation { get => analyzingRotation; }
    private GameObject _originalParent;
    private GameObject _3DForm;
    private GameObject _2DForm;
    

    In_Game_Tool info;

    //public static Prop_Controller instance;


    

    void Start()
    {
        if (gameObject.tag == "Tool")
        {
            info = GetComponent<In_Game_Tool>();
            if (transform.childCount > 1)
            {
                _3DForm = transform.GetChild(0).gameObject;
                _2DForm = transform.GetChild(1).gameObject;
                _2DForm.GetComponent<Image>().sprite = info.sprite;
                _2DForm.SetActive(false);
            }
        }
        
        _originalParent = transform.parent.gameObject;
        
        
            
    }
    public void ActionButtonOnIt()
    {
        if (gameObject.tag == "Tool") { PutInTempInventory(); }
        if (gameObject.tag == "Analizable") { Main_Character_Controller_v2.instance.StartAnalizing(gameObject); };
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void PutInTempInventory()
    {
        GameObject inventory = Inventory_Temp.instance.gameObject;
        GameObject inventoryPlaces = inventory.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        _3DForm.SetActive(false);
        _2DForm.SetActive(true);
        inventory.SetActive(true);
        inventory.GetComponent<Inventory_Temp>().InitialAnimation();
        //if (!inventory.activeSelf)
        //{
            
        //}
        //else
        //{
            
        //}
        transform.SetParent(inventoryPlaces.transform.GetChild(inventory.GetComponent<Inventory_Temp>().propsGrabbed.Count));
        inventory.GetComponent<Inventory_Temp>().propsGrabbed.Add(gameObject);
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one * spriteScale;        
        if (transform.childCount > 1)
        {
            _2DForm.GetComponent<Image>().sprite = info.sprite;
        }

        info.GrabIt();

        //if (inventoryPlaces.transform.childCount > Inventory_Temp.instance.propsGrabbed.Count)
        //{
            
                
        //}
        //else { Debug.Log("Invenario lleno"); }       
    }
}
