using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRestorePuzzleParent : Prop
{
    [Tooltip("List of pieces/parts that complete the puzzle once restored.")]
    public List<GameObject> VictoryConditions;
    [Tooltip("The final position those parts would have.")]
    public List<GameObject> FinalPositionOfItem;
    public bool[] conditionAchived;


    // Start is called before the first frame update
    void Start()
    {
        base.AddToObserversList();
        conditionAchived = new bool[VictoryConditions.Count];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnActionButton()
    {
        TryToRestore();
        if (!CheckForVictory())
        {
            base.OnActionButton();
        }
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
