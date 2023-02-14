using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chosen_Level : MonoBehaviour
{
    public bool isCurrentlyActive;
    public void ActivateBook()
    {
        if (!isCurrentlyActive) { isCurrentlyActive = true; }
    }
    public void DeactivateBook()
    {
        if (isCurrentlyActive) { isCurrentlyActive = false; }
    }
}
