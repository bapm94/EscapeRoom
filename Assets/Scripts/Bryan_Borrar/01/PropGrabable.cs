using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropGrabable : PropAnalizable
{
    
    [SerializeField] protected float spriteScale = 0.5f;
    public bool restored = false;

    private GameObject _originalParent;
    private GameObject _3DForm;
    private GameObject _2DForm;


    In_Game_Tool info;

    [SerializeField] ExtraActionsTemplate extraActionScript;

    private void Start()
    {
        gameObject.TryGetComponent<ExtraActionsTemplate>(out ExtraActionsTemplate extra);
        extraActionScript = extra;

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
        inventory.GetComponent<Inventory_Temp>().OpenedByPicking();
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
        if (gameObject.layer == 8)
        {
            if (!restored)
            {
                Debug.Log("000000" + gameObject);
                base.OnActionButton();
            }
            else if (restored)
            {
                Debug.Log("�" + extraActionScript);
                extraActionScript.ExtraAction();
            }
        }
       


    }
    protected override void OnInventoryButton()
    {
        if (gameObject.layer == 9 && !Dialogue_System_Controller.instance.dialogueOnGoing)
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
}
