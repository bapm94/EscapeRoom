using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restoring_Puzzle : MonoBehaviour
{
    public List<GameObject> VictoryConditions;
    public List<GameObject> FinalPositionOfItem;
    public bool[] conditionAchived;

    // Start is called before the first frame update
    void Start()
    {
        conditionAchived = new bool[VictoryConditions.Count];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActionButtonOnIt()
    {
        TryToRestore();
    }

    public void TryToRestore()
    {
        for (int i = 0; i < VictoryConditions.Count; i++)
        {
            for (int x = 0; x < Inventory_Temp.instance.propsGrabbed.Count; x++)
            {
                if (VictoryConditions[i] == Inventory_Temp.instance.propsGrabbed[x])
                {
                    conditionAchived[i] = true;
                    GameObject part = Inventory_Temp.instance.propsGrabbed[x];
                    part.transform.SetParent(FinalPositionOfItem[i].transform);
                    part.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                    part.transform.localScale = Vector3.one;
                    part.transform.GetChild(0).gameObject.SetActive(true);
                    part.transform.GetChild(1).gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
    public bool CheckForVictory()
    {
        bool victory = false;
        int count = 0;
        for (int i = 0; i < VictoryConditions.Count; i++)
        {
            if (conditionAchived[i])
            {
                count++;
            }
        }
        if (count == VictoryConditions.Count)
        {
            victory = true;
        }
        return victory;

    }
}
