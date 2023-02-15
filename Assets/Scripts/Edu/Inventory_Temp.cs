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



    public bool openByPlayer;
    float timer;
    [SerializeField] float timeToClose = 3;
    [SerializeField] float animationTime = 5f;

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
    }

    private void OnEnable()
    {
        InitialAnimation();
        if (!openByPlayer) { LeanTween.delayedCall(timeToClose, () => CloseInventory()); }
    }

    public void InitialAnimation()
    {
        LeanTween.cancel(gameObject);
        
        LeanTween.moveLocalX(gameObject, 0, animationTime / 10);
        timer = 0;
    }

    public void CloseInventory()
    {
        LeanTween.cancel(gameObject);
        openByPlayer = false;
        GetComponent<Button>().Select();
        LeanTween.moveLocalX(gameObject, -280, (animationTime / 10)).setOnComplete(() => LeanTween.delayedCall(0.02f, () => gameObject.SetActive(false)));
    }
}
