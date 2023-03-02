using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TakeOffCap : ExtraActionsTemplate
{
    public bool isFilled { get; set; }

    public override void ExtraActionOnCollected()
    {
        var cap = transform.GetChild(0).GetChild(1).gameObject;

        if (cap.activeSelf)
        {
            cap.SetActive(false);
        }
        else
        {
            cap.SetActive(true);
        }
    }

    public override void ExtraActionOnRestoring()
    {
        gameObject.GetComponent<PropGrabable>().canBeCollectedAgain = false;
    }
}
