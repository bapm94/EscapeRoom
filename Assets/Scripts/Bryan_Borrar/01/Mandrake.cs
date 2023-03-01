using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandrake : ExtraActionsTemplate
{
    [SerializeField] PropGrabable grabable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ExtraActionOnCollected()
    {
        grabable.enabled = true;
        grabable.AddToObserversList();
    }

}
