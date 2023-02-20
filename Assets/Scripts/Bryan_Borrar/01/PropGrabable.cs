using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropGrabable : PropAnalizable
{
    
    [SerializeField] protected float spriteScale = 0.5f;
    //[SerializeField] float analyzingScale = 1f;
    //[SerializeField] Vector3 analyzingRotation;
    //[SerializeField] bool isTool;

    //public float AnalyzingScale { get => analyzingScale; }
    //public Vector3 AnalyzingRotation { get => analyzingRotation; }
    private GameObject _originalParent;
    private GameObject _3DForm;
    private GameObject _2DForm;


    In_Game_Tool info;

    //public static Prop_Controller instance;
    //[SerializeField] GameObject lockScreen;
    private void Start()
    {
        base.AddToObserversList();
        info = GetComponent<In_Game_Tool>();
        if (transform.childCount > 1)
        {
            _3DForm = transform.GetChild(0).gameObject;
            _2DForm = transform.GetChild(1).gameObject;
            _2DForm.GetComponent<Image>().sprite = info.sprite;
            _2DForm.SetActive(false);
        }
        _originalParent = transform.parent.gameObject;
    }        
    
    public void PutInTempInventory()
    {
        GameObject inventory = Inventory_Temp.instance.gameObject;
        GameObject inventoryPlaces = inventory.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        _3DForm.SetActive(false);
        _2DForm.SetActive(true);
        inventory.SetActive(true);
        //inventory.GetComponent<Inventory_Temp>().InitialAnimation();

        transform.SetParent(inventoryPlaces.transform.GetChild(inventory.GetComponent<Inventory_Temp>().propsGrabbed.Count));
        inventory.GetComponent<Inventory_Temp>().propsGrabbed.Add(gameObject);
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one * spriteScale;
        if (transform.childCount > 1)
        {
            _2DForm.GetComponent<Image>().sprite = info.sprite;
        }

        info.GrabIt();

    }

    protected override void OnActionButton()
    {
        base.OnActionButton();

        
    }
    protected override void OnInventoryButton()
    {
        if (Main_Character_Controller_v2.instance.isAnalizingOject)
        {
            Main_Character_Controller_v2.instance.isAnalizingOject = false;
            PutInTempInventory();
            Main_Camera_Controller.instance.ChangeFollowStatus(true);
            //Main_Character_Controller_v2.instance.PerceivedGO = null;
        }
    }
}
