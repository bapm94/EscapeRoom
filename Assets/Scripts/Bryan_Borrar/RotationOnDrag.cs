using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class RotationOnDrag : MonoBehaviour
{
    private Quaternion originalRotation;
    private float startAngle = 0;
    [SerializeField] int dialVictoryValue;
    public bool victory  {get; set;}
    [SerializeField] PropCodePuzzle puzzleSolver;


    //[SerializeField] Vector3 rotationAxis = new Vector3 (0,0,1);

    // Start is called before the first frame update
    void Start()
    {
        victory = false;
        originalRotation = gameObject.transform.localRotation;
        if (dialVictoryValue < 0)
        {
            dialVictoryValue = 360 + dialVictoryValue;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vector = Input.mousePosition - screenPos;
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.AngleAxis(angle - startAngle, transform.forward);
        newRotation.y = 0; //see comment from above 
        newRotation.eulerAngles = new Vector3(0, 0, newRotation.eulerAngles.z);
        transform.localRotation = originalRotation * newRotation;
        

        if (dialVictoryValue - 10 <= transform.localEulerAngles.z && transform.localEulerAngles.z < dialVictoryValue + 10)
        {
            victory = true;
            
        }
        else { victory = false; }
        
    }
    

    public void ShowState()
    {
        Debug.Log(victory);
    }
    private void OnMouseUp()
    {
        if (puzzleSolver != null)
        {
            puzzleSolver.CheckForVictory();
        }
    }

}
