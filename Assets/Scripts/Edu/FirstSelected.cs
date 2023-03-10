using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstSelected : MonoBehaviour
{
    Button firstSelected;

    private void OnEnable()
    {
        firstSelected = gameObject.GetComponent<Button>();
        firstSelected.Select();
        
    }
}
