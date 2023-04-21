using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Check : MonoBehaviour
{
    public bool isForAndroid;
    private void Awake()
    {
        if (isForAndroid) 
        {
            //if (Application.platform != RuntimePlatform.Android) { this.gameObject.SetActive(false); }
        }
        else if (!isForAndroid)
        {
            if (Application.platform == RuntimePlatform.Android) { this.gameObject.SetActive(false); }
        }
    }
}
