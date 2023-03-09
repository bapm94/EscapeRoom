using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeapotNoteExtra : ExtraActionsTemplate
{
    [SerializeField] GameObject noteFragment;

    private void Start()
    {
        
    }
    public override void ExtraActionOnInteraction()
    {
        //noteFragment.SetActive(!noteFragment.activeSelf);
        noteFragment.layer = 9;
    }
    public override void ExtraActionOnStopAnalizing()
    {
        noteFragment.layer = 0;
    }
}
