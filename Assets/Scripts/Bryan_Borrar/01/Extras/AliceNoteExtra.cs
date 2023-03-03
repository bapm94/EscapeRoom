using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceNoteExtra : ExtraActionsTemplate
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ExtraActionOnInteraction()
    {
        InGame_Menu_Controller.instance.IndexChange(3);
        gameObject.layer = 6;
        Main_Camera_Controller.instance.ChangeFollowStatus(false);
    }
}
