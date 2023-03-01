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
        Debug.Log("pepe");

        if (gameObject.layer == 8)
        {
            Debug.Log("pepe");
            GameObject tutorialObject = GameObject.Find("Tutorial1");
            Main_Character_Controller_v2 character = Main_Character_Controller_v2.instance;
            if (character.physicalMenu != null)
            {
                if (tutorialObject.GetComponent<Tutorial_Manager>().tutorialActive)
                {
                    base.OnActionButton();
                    tutorialObject.GetComponent<Tutorial_Manager>().Deactivate();
                    
                }                
                else if (!tutorialObject.GetComponent<Tutorial_Manager>().tutorialActive){ character.physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoMenu();  }
                
            }
        }
       
    }


}
