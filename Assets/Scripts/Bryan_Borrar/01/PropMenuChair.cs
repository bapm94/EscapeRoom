using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMenuChair : Prop
{


    // Start is called before the first frame update
    void Start()
    {
        base.AddToObserversList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnActionButton()
    {
        base.OnActionButton();
        if (gameObject.layer == 8)
        {
            GameObject tutorialObject = GameObject.Find("Tutorial1");
            Main_Character_Controller_v2 character = Main_Character_Controller_v2.instance;
            if (character.physicalMenu != null)
            {
                if (tutorialObject.GetComponent<Tutorial_Manager>().tutorialActive)
                {
                    tutorialObject.GetComponent<Tutorial_Manager>().Deactivate();
                    Dialogue_System_Controller.instance.GetDialogueInfo(12, 15);
                    //character.physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoMenu();
                }
                else { character.physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoMenu(); }
            }
        }
       
    }
}
