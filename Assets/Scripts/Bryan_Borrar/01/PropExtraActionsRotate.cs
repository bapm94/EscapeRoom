using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropExtraActionsRotate : ExtraActionsTemplate
{
    [SerializeField] float angleAmount;
    [SerializeField] Vector3 angles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ExtraAction()
    {
        
        float angle = angleAmount + transform.eulerAngles.y;
        //if (angles.x == 1)
        //{
        //    angle = angleAmount + transform.eulerAngles.x;
        //}
        //else if (angles.y == 1)
        //{
        //    angle = angleAmount + transform.eulerAngles.y;
        //}
        //else if (angles.z == 1)
        //{
        //    angle = angleAmount + transform.eulerAngles.z;
        //}
        //transform.Rotate(angles, angle, Space.Self);
        Debug.Log("caraculo" + angle);
        LeanTween.rotateY(gameObject, angle, 1);
    }
}
