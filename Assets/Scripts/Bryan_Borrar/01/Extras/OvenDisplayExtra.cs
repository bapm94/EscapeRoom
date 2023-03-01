using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenDisplayExtra : ExtraActionsTemplate
{
    bool beingInteract = false;
    // Start is called before the first frame update
    void Start()
    {
        Main_Interacction_Controller.instance.onBackButton += OnBackButton;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void ExtraActionOnInteraction()
    {
        beingInteract = true;
        InGame_Menu_Controller.instance.IndexChange(1);
        Main_Camera_Controller.instance.ChangeFollowStatus(false);
        gameObject.GetComponent<Prop>().SwitchInteractability(false);
        
    }
    public void OnBackButton()
    {
        if (beingInteract == true)
        {
            beingInteract = false;
            gameObject.GetComponent<Prop>().SwitchInteractability(true);
        }
    }
    
}
