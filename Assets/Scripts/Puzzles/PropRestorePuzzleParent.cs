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
    public int count = 0;
    ExtraActionsTemplate extra;

    public GameObject grabedObjectParent;
    GameObject grabedObject;
    void Start()
    {
        Initialized();
    }

    public void Initialized()
    {
        base.AddToObserversList();
        
        conditionAchived = new bool[VictoryConditions.Count];
        gameObject.TryGetComponent<ExtraActionsTemplate>(out ExtraActionsTemplate extraS);
        if (extraS != null) { extra = extraS; }
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
            else if (CheckForVictory() && extra != null) { extra.ExtraActionOnVictory(); }
        }   
    }


    public void TryToRestore()
    {
        if (Inventory_Temp.instance != null)
        {
            grabedObjectParent = Inventory_Temp.instance.gameObject.transform.GetChild(1).gameObject;
            if (grabedObjectParent.transform.childCount > 0) { grabedObject = grabedObjectParent.transform.GetChild(0).gameObject; }
            for (int i = 0; i < VictoryConditions.Count; i++)
            {
                if (VictoryConditions[i] == grabedObject)
                {
                    conditionAchived[i] = true;
                    GameObject part = grabedObject; /*Inventory_Temp.instance.propsGrabbed[x];*/
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
                        Inventory_Temp.instance.propsGrabbed.Remove(part);
                        count++;
                        if (extra != null) extra.ExtraActionOnRestoring();
                        Inventory_Temp.instance.ElementRemoved();


                        ArmAnimation.instance.PlayArmAwayAnimation();

                    }
                    if (extra != null) { extra.ExtraActionOnPositioning(); }

                }
            }
        

            //for (int x = 0; x < Inventory_Temp.instance.propsGrabbed.Count; x++)
            //{
                
            //    //else break;
            //}
        }
    }

    public bool CheckForVictory()
    {
        bool victory = false;

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
            //gameObject.SetActive(false);
        }
        else {victory = false; }
        return victory;
    }

    private void OnDisable()
    {
        SubstractFromObserversList();
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("entrando " + other.name);
    }

}
