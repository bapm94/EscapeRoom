using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TakeOffCap : ExtraActionsTemplate
{
    public bool isFilled { get; set; }
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
        var cap = transform.GetChild(0).GetChild(1).gameObject;

        if (cap.activeSelf)
        {
            cap.SetActive(false);
        }
        else
        {
            cap.SetActive(true);
        }
    }
}
