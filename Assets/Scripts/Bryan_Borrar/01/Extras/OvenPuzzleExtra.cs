using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenPuzzleExtra : ExtraActionsTemplate
{
    [SerializeField] GameObject ovenDoor;
    
    public override void ExtraActionOnVictory()
    {
        LeanTween.rotateLocal(ovenDoor, Vector3.zero, 1.5f);
        CluesController.instance.ChangeClue(5);
        CluesController.instance.insigth += 10;
    }
}
