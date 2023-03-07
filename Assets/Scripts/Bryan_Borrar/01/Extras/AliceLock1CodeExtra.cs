using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceLock1CodeExtra : ExtraActionsTemplate
{

    [SerializeField] Animator animator;
    [SerializeField] GameObject cupboard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public override void ExtraActionOnInteraction()
    //{
    //    cupboard.layer = 0;
    //    cupboard.tag = "111";
    //    Destroy(cupboard.GetComponent<Prop>());
    //}
    public override void ExtraActionOnVictory()
    {
        animator.SetTrigger("Unlocked");
        CluesController.instance.insigth += 10;
        CluesController.instance.ChangeClue(5);
    }
}
