using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtonAction : MonoBehaviour
{
    GameObject holdingPlace;
    int thisOrder;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i) == gameObject)
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
                GameObject goToHold = transform.GetChild(1).gameObject;
                goToHold.transform.SetParent(holdingPlace.transform);
                Inventory_Temp.instance.ElementRemoved();
                goToHold.transform.localScale = Vector3.zero;
                ArmAnimation.instance.PlayInventoryItemAnimation(goToHold.name);
                //ArmAnimation.instance.PlayArmAwayAnimation();
                holdingPlace.transform.GetChild(0).GetComponent<PropGrabable>().ReorderInTempInventory(thisOrder);


                
            }
        }
    }
}
