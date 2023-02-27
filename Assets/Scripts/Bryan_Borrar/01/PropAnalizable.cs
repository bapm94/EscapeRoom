using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropAnalizable : Prop
{
    
    [SerializeField] Vector3 localAnalizingScale;
    [SerializeField] Vector3 localAnalizingEulerAngles;
    protected bool isBeingAnalized = false;
    private void Start()
    {
        base.AddToObserversList();
    }
    protected override void OnActionButton()
    {
        
        if (gameObject.layer == 8 && !isBeingAnalized)
        {
            base.OnActionButton();
            isBeingAnalized =true;
            if (localAnalizingScale != Vector3.one || localAnalizingEulerAngles != Vector3.zero)
            {
                Main_Character_Controller_v2.instance.StartAnalizing(gameObject, localAnalizingScale, localAnalizingEulerAngles);
            }
            else
            {
                Main_Character_Controller_v2.instance.StartAnalizing(gameObject);
            }
            
        }
        else if (isBeingAnalized)
        {
            isBeingAnalized = false;
            Main_Character_Controller_v2.instance.StopAnalizing();
        }
    }
}
