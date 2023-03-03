using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMenuChair : Prop
{
    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnActionButton()    
    {
        if (gameObject.layer == 8)
        {
            Main_Character_Controller_v2 character = Main_Character_Controller_v2.instance;
            if (Main_Game_Manager.instance.objectsChecked)
            {
                base.OnActionButton();
                if (character.physicalMenu != null && character.canMove)
                {
                    character.physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoMenu();
                }
            }
            else { Dialogue_System_Controller.instance.GetDialogueInfo(21, 21); }
        }  
    }


}
