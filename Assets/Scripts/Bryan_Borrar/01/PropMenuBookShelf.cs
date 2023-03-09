using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMenuBookShelf : Prop
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
        
        if (gameObject.layer == 8)
        {
            base.OnActionButton();
            Main_Character_Controller_v2 character = Main_Character_Controller_v2.instance;
            if (character.physicalMenu != null)
            {
                if (Main_Game_Manager.instance.aliceLevelStarted == false)
                {
                    if (Main_Game_Manager.instance.tutorialActive3) { Main_Game_Manager.instance.tutorialActive3 = false; }
                    else { character.physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoLevelMenu(); }
                }
                else { character.physicalMenu.GetComponent<InGame_Menu_Controller>().GoIntoLevelMenu(); }
            }
            gameObject.layer = 6;
            Main_Character_Controller_v2.instance.ChangeSubmeshesLayer(gameObject, 6);
        }
    }
}
