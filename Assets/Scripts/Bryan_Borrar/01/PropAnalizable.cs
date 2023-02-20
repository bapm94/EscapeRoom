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
        base.OnActionButton();
        if (gameObject.layer == 8)
        {
            isBeingAnalized=true;
            if (localAnalizingScale != Vector3.one || localAnalizingEulerAngles != Vector3.zero)
            {
                Main_Character_Controller_v2.instance.StartAnalizing(gameObject, localAnalizingScale, localAnalizingEulerAngles);
            }
            else
            {
                Main_Character_Controller_v2.instance.StartAnalizing(gameObject);
            }
            
        }
    }
}
