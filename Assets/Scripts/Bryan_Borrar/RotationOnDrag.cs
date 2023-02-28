using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationOnDrag : MonoBehaviour
{
    private Quaternion originalRotation;
    private float startAngle = 0;
    //[SerializeField] Vector3 rotationAxis = new Vector3 (0,0,1);

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = gameObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        Debug.Log("Dragging");
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vector = Input.mousePosition - screenPos;
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.AngleAxis(angle - startAngle, transform.forward);
        newRotation.y = 0; //see comment from above 
        newRotation.eulerAngles = new Vector3(0, 0, newRotation.eulerAngles.z);
        transform.localRotation = originalRotation * newRotation;
        Debug.Log(newRotation.ToString());
    }
}
