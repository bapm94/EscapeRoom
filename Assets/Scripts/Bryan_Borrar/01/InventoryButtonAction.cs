using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtonAction : MonoBehaviour
{
    GameObject holdingPlace;
    // Start is called before the first frame update
    void Start()
    {
        
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
            }            
        }
        else if (holdingPlace != null && holdingPlace.transform.childCount == 1)
        {
            if (transform.childCount > 1)
            {
                ArmAnimation.instance.PlayArmAwayAnimation();
                holdingPlace.transform.GetChild(0).GetComponent<PropGrabable>().PutInTempInventory();
                GameObject goToHold = transform.GetChild(1).gameObject;
                goToHold.transform.SetParent(holdingPlace.transform);
                goToHold.transform.localScale = Vector3.zero;
                ArmAnimation.instance.PlayInventoryItemAnimation(goToHold.name);
            }
        }
    }
}
