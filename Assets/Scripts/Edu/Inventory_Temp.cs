using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Temp : MonoBehaviour
{
    string[] puzzles;
    bool[] resolved;
    float[] resolutionTime;
    int[] insight;

    GameObject[] prop;
    List<GameObject> propsGrabbed = new List<GameObject>();

    void Start()
    {
        for(int i = 0 ; i < prop.Length; i++)
        {
            prop[i].GetComponent<In_Game_Tool>().element_Local_Index = i;
        }
    }

}
