using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceLock1CodeExtra : ExtraActionsTemplate
{
    [SerializeField] Animator animator;
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
        animator.SetTrigger("Unlocked");
    }
}
