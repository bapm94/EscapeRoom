using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_Manager : MonoBehaviour
{
    public bool triggerIsGameObject;
    public GameObject trigger;

    public bool triggerIsCondition;
    public int conditionNumber;

    void Start()
    {

    }

    void FixedUpdate()            
    {
        if (triggerIsCondition)
        {
            if (conditionNumber == 0) 
            {
                if (Main_Character_Controller_v2.instance.isAnalizingOject && !trigger.activeSelf) { gameObject.transform.GetChild(0).gameObject.SetActive(true); }
                else { gameObject.transform.GetChild(0).gameObject.SetActive(false); }
            }

            if (conditionNumber == 1) 
            {
                if (Main_Character_Controller_v2.instance.canMove) { Debug.Log("AAAAA"); gameObject.transform.GetChild(0).gameObject.SetActive(true); } 
                else { gameObject.transform.GetChild(0).gameObject.SetActive(false); }
            }

            if (conditionNumber == 2) 
            {
                if (Inventory_Temp.instance._parentRoot.activeSelf && !Main_Character_Controller_v2.instance.canMove) { gameObject.transform.GetChild(0).gameObject.SetActive(true); } 
                else { gameObject.transform.GetChild(0).gameObject.SetActive(false); }
            }
        }

        else if (triggerIsGameObject)
        {
            if (trigger.activeInHierarchy == true) { gameObject.transform.GetChild(0).gameObject.SetActive(true); }
            else { gameObject.transform.GetChild(0).gameObject.SetActive(false); }
        }
    }
}
