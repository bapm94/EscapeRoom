using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Temp : MonoBehaviour
{
    string[] puzzles;
    bool[] resolved;
    float[] resolutionTime;
    int[] insight;


    public GameObject _parentRoot;
    public bool openByPlayer; /*{ get; set; }*/
    float timer;
    [SerializeField] float timeToClose = 3;
    [SerializeField] float animationTime = 5f;
    [SerializeField] public GameObject firstSelect;

    GameObject buttonsParent;
    GameObject[] itemSpots;

    public GameObject[] prop;
    public List<GameObject> propsGrabbed = new List<GameObject>();

    public static Inventory_Temp instance;
    

    void Start()
    {
        #region Singleton

        if (Inventory_Temp.instance == null)
        {
            Inventory_Temp.instance = this;
        }
        else
        {
            Destroy(this);
        }
        #endregion
        for (int i = 0 ; i < prop.Length; i++)
        {
            prop[i].GetComponent<In_Game_Tool>().element_Local_Index = i;
        }
        gameObject.SetActive(false);
        buttonsParent = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        itemSpots = new GameObject[buttonsParent.transform.childCount];
        for (int i = 0; i < buttonsParent.transform.childCount; i++)
        {
            itemSpots[i] = buttonsParent.transform.GetChild(i).gameObject;
        }
    }

    private void OnEnable()
    {
        ////InitialAnimation();
        if (openByPlayer) { firstSelect.transform.GetComponent<Button>().Select();   }
        //else        { LeanTween.delayedCall(timeToClose, () => CloseInventory()); }
    }

    public void InitialAnimation()
    {
        LeanTween.cancel(_parentRoot);
        
        LeanTween.moveLocalX(_parentRoot, 0, animationTime / 10);
        timer = 0;
    }

    public void CloseInventory()
    {
        LeanTween.cancel(_parentRoot);
        //openByPlayer = false;
        GetComponent<Button>().Select();
        LeanTween.moveLocalX(_parentRoot, -280, (animationTime / 10)).setOnComplete(() => LeanTween.delayedCall(0.02f, () => _parentRoot.SetActive(false)));
    }
    public void OpenedByPicking()
    {
        InitialAnimation();
        LeanTween.delayedCall(timeToClose, () => CloseInventory());
    }

    public void ElementRemoved()
    {
        if (propsGrabbed.Count > 0)
        {
            List<GameObject> temporalList = new List<GameObject>();
            for (int i = 0; i < propsGrabbed.Count; i++)
            {
                if (propsGrabbed[i] != null)
                {
                    
                    temporalList.Add(propsGrabbed[i]);
                    propsGrabbed[i].GetComponent<PropGrabable>().ReorderInTempInventory(i);
                }
                
                
            }

            propsGrabbed = temporalList;
        }

    }
}
