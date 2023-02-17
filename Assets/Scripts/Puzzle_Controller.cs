using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle_Controller : MonoBehaviour
{
    bool puzzleSolved = false; // FirstPuzzle
    //TMP_Dropdown victoryCondition;
    //List<string> victoryConditions = new List<string> {"findObject", "combineObjects", "password", "unlock" };
    public List<GameObject> VictoryConditions /*= new List<GameObject> { "findObject", "combineObjects", "password", "unlock" }*/;
    public bool[] conditionAchived;
   
    void Start()
    {
        conditionAchived = new bool[VictoryConditions.Count];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log( CheckForVictory());
        }
    }


    public bool CheckForVictory()
    {
        bool victory = false;
        int count = 0;
        for (int i = 0; i < VictoryConditions.Count; i++)
        {
            for (int x = 0; x < Inventory_Temp.instance.propsGrabbed.Count; x++)
            {
                if (VictoryConditions[i] == Inventory_Temp.instance.propsGrabbed[x])
                {
                    conditionAchived[i] = true;
                    count++;
                }
            }
                


            //if (conditionAchived[i])
            //{
            //    count++;
            //}
            //conditionAchived[i] = false;
        }
        if (count == VictoryConditions.Count)
        {
            victory = true;
        }
        return victory;
    }
}
