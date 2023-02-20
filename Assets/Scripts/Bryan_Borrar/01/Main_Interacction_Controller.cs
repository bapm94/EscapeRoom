using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This scipt is the Subject of the observer pattern that allows interaction with objects in scene.
public class Main_Interacction_Controller : MonoBehaviour
{
    public static Main_Interacction_Controller instance;

    void Awake()
    {
        instance = this;
    }

    public event Action onActionButton;
    public event Action onInventoryButton;
    public event Action onBackButton;
    public void ActionButton()
    {
        
        if (onActionButton != null)
        {
            onActionButton();            
        }
        
    }

    public void YButton()
    {
        if (onInventoryButton != null)
        {
            onInventoryButton();
        }
    }

    public void BackButton()
    {
        if (onBackButton != null)
        {
            onBackButton();
        }
    }
}
