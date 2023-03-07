using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TakeOffCap : ExtraActionsTemplate
{
    public bool isFilled { get; set; }
    int pointsGiven = 0;
    bool clueChanged;
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
        if (pointsGiven <= 1)
        {
            CluesController.instance.insigth += 10;
            pointsGiven++;
        }
        
    }
    public override void ExtraActionOnInteraction()
    {
        CluesController.instance.ChangeClue(2);
    }
}
