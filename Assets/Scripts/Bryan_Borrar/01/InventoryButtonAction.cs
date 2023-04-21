using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtonAction : MonoBehaviour
{
    GameObject holdingPlace;
    public int thisOrder;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i).gameObject == gameObject)
            {
                thisOrder = i;  
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HoldThis()
    {
        if (Inventory_Temp.instance != null)
        {
            holdingPlace = Inventory_Temp.instance.gameObject.transform.GetChild(1).gameObject;
        }
        
        if (holdingPlace != null && holdingPlace.transform.childCount < 1) //Solo si hay sitio para aguantar el objeto y además no esta ocupado
        {
            if (transform.childCount > 1)
            {
                GameObject goToHold = transform.GetChild(1).gameObject;
                goToHold.transform.SetParent(holdingPlace.transform);
                goToHold.transform.localScale = Vector3.zero;
                ArmAnimation.instance.PlayInventoryItemAnimation(goToHold.name);
                Inventory_Temp.instance.propsGrabbed.Remove(goToHold);
                Inventory_Temp.instance.ElementRemoved();
            }            
        }
        else if (holdingPlace != null && holdingPlace.transform.childCount == 1)
        {
            if (transform.childCount > 1)
            {
                GameObject goToStopHolding = holdingPlace.transform.GetChild(0).gameObject;
                GameObject goToHold = transform.GetChild(1).gameObject;


                goToHold.transform.SetParent(holdingPlace.transform);
                Inventory_Temp.instance.propsGrabbed.Remove(goToHold);
                
                goToHold.transform.localScale = Vector3.zero;

                goToStopHolding.GetComponent<PropGrabable>().ReorderInTempInventory(thisOrder);
                //holdingPlace.transform.GetChild(0).GetComponent<PropGrabable>().ReorderInTempInventory(thisOrder);

                Inventory_Temp.instance.propsGrabbed.Add(goToStopHolding);

                ArmAnimation.instance.PlayInventoryItemAnimation(goToHold.name);
                Inventory_Temp.instance.ElementRemoved();
            }
        }

        Main_Character_Controller_v2.instance.OnY_Button();

    }
}
