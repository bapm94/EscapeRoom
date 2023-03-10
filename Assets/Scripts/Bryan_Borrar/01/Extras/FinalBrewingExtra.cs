using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBrewingExtra : ExtraActionsTemplate
{
    [SerializeField] GameObject victory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ExtraActionOnVictory()
    {
        Main_Camera_Controller.instance.ChangeFollowStatus(false);
        victory.SetActive(true);
    }
}
