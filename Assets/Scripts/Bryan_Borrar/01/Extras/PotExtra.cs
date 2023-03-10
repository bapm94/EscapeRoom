using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotExtra : ExtraActionsTemplate
{
    [SerializeField] GameObject seeds;
    


    public override void ExtraAction() //Once set in place the action gets call when interacted.
    {
        GameObject holdingPlace = Inventory_Temp.instance.gameObject.transform.GetChild(1).gameObject;
        if (holdingPlace != null && holdingPlace.transform.childCount == 1 )
        {
            
            if (holdingPlace.transform.GetChild(0).gameObject == seeds)
            {
               
                GameObject part = seeds;
                PropGrabable script = part.GetComponent<PropGrabable>();
                part.TryGetComponent<ExtraActionsTemplate>(out ExtraActionsTemplate extra);
                if (!script.restored)
                {
                    
                    part.transform.SetParent(gameObject.transform);
                    part.transform.localScale = Vector3.zero;
                    script.restored = true;
                    Inventory_Temp.instance.propsGrabbed.Remove(part);
                    Inventory_Temp.instance.ElementRemoved();
                    ArmAnimation.instance.PlayArmAwayAnimation();
                }
                if (extra != null) { extra.ExtraActionOnPositioning(); }
                gameObject.GetComponent<PropGrabable>().SwitchInteractability(false);
            }
        }







        //    for (int x = 0; x < Inventory_Temp.instance.propsGrabbed.Count; x++)
        //{
        //    if (seeds == Inventory_Temp.instance.propsGrabbed[x])
        //    {
        //        GameObject part = Inventory_Temp.instance.propsGrabbed[x];
        //        PropGrabable script = part.GetComponent<PropGrabable>();
        //        part.TryGetComponent<ExtraActionsTemplate>(out ExtraActionsTemplate extra);
        //        if (!script.restored)
        //        {
        //            part.transform.SetParent(gameObject.transform);
        //            part.transform.localScale = Vector3.zero;
        //            script.restored = true;
        //            Inventory_Temp.instance.propsGrabbed.Remove(part);
                    
        //        }
        //        if (extra != null) { extra.ExtraActionOnPositioning(); }
        //        gameObject.GetComponent<PropGrabable>().SwitchInteractability(false);
        //        //Debug.Log("PLant growing");
        //    }
        //}
    }
    public override void ExtraActionOnCollected()
    {

    }
    public override void ExtraActionOnVictory()
    {
        
    }
}
