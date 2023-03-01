using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraActionsTemplate : MonoBehaviour
{
    Vector3 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void ExtraActionOnInteraction()
    {

    }
    public virtual void ExtraAction()
    {

    }
    public virtual void ExtraActionOnCollected()
    {

    }
    public virtual void ExtraActionOnVictory()
    {

    }

    public void SetDefaultPos(Vector3 x)
    {
        defaultPos = x;
    }

    public Vector3 GetDefaultPos()
    {
        return defaultPos;
    }
}
