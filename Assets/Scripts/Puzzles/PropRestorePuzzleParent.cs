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
    [SerializeField] GameObject subMision;


    //[SerializeField] ExtraActionsTemplate extraActionScript;
    
    // Start is called before the first frame update
    void Start()
    {
        AddToObserversList();
        conditionAchived = new bool[VictoryConditions.Count];
        gameObject.TryGetComponent<ExtraActionsTemplate>(out ExtraActionsTemplate extra);        
    }


    protected override void OnActionButton()
    {
        if (gameObject.layer == 8)
        {
            TryToRestore();
            if (!CheckForVictory())
            {
                base.OnActionButton();
            }
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
                    PropGrabable script = part.GetComponent<PropGrabable>();
                    part.TryGetComponent<ExtraActionsTemplate>(out ExtraActionsTemplate extra);
                    if (!script.restored)
                    {
                        part.transform.SetParent(FinalPositionOfItem[i].transform);
                        part.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                        part.transform.localScale = Vector3.one;
                        part.transform.GetChild(0).gameObject.SetActive(true);
                        part.transform.GetChild(1).gameObject.SetActive(false);
                        script.restored = true;
                    }
                    extra.ExtraAction();
                }
                //else break;
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
            if (subMision != null) { subMision.SetActive(true); }
            if (gameObject.tag == "000")
            {
                gameObject.layer = 0;
                gameObject.tag = "111";
                Main_Character_Controller_v2.instance.PerceivedGO = null;

            }
            this.enabled = false;
        }
        return victory;

    }

    private void OnDisable()
    {
        SubstractFromObserversList();
    }
}
