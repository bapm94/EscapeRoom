using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Prop_Controller : MonoBehaviour
{
    [SerializeField] float spriteScale = 0.5f;


    private GameObject _originalParent;
    private GameObject _3DForm;
    private GameObject _2DForm;
    

    In_Game_Tool info;

    public static Prop_Controller instance;
    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<In_Game_Tool>();
        _originalParent = transform.parent.gameObject;
        _3DForm = transform.GetChild(0).gameObject;
        _2DForm = transform.GetChild(1).gameObject;
        _2DForm.GetComponent<SpriteRenderer>().sprite = info.sprite;
        _2DForm.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            PutInTempInventory();
        }
        
    }

    public void PutInTempInventory()
    {
        _3DForm.SetActive(false);
        _2DForm.SetActive(true);
        GameObject inventory = Camera.main.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        transform.SetParent(inventory.transform.GetChild(inventory.GetComponent<Inventory_Temp>().propsGrabbed.Count));
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one * spriteScale;
        info.isSprite = true;
    }
}
