using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Prop_Controller : MonoBehaviour
{
    [SerializeField] float spriteScale = 0.5f;


    private GameObject _originalParent;
    private GameObject _3DForm;
    private GameObject _2DForm;
    

    In_Game_Tool info;

    //public static Prop_Controller instance;
    

    void Start()
    {
        info = GetComponent<In_Game_Tool>();
        _originalParent = transform.parent.gameObject;
        _3DForm = transform.GetChild(0).gameObject;
        _2DForm = transform.GetChild(1).gameObject;
        _2DForm.GetComponent<Image>().sprite = info.sprite;
        _2DForm.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PutInTempInventory()
    {
        GameObject inventory = Inventory_Temp.instance.gameObject;
        
        if (inventory.transform.childCount > inventory.GetComponent<Inventory_Temp>().propsGrabbed.Count)
        {
            _3DForm.SetActive(false);
            _2DForm.SetActive(true);
            if (!inventory.activeSelf)
            {
                inventory.SetActive(true);
            }
            else
            {
                inventory.GetComponent<Inventory_Temp>().InitialAnimation();
            }
            transform.SetParent(inventory.transform.GetChild(inventory.GetComponent<Inventory_Temp>().propsGrabbed.Count));
            inventory.GetComponent<Inventory_Temp>().propsGrabbed.Add(gameObject);
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one * spriteScale;
            info.isSprite = true;
            _2DForm.GetComponent<Image>().sprite = info.sprite;
        }
        else { Debug.Log("Invenario lleno"); }       
    }
}
