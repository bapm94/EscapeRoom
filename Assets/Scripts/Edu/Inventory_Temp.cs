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
    }

    public void InitialAnimation()
    {
        LeanTween.cancel(gameObject);
        
        LeanTween.moveLocalX(gameObject, 0, animationTime / 10);
        timer = 0;
    }

    private void Update()
    {
        if (!openByPlayer)
        {
            timer += Time.deltaTime;
            if (timer >= timeToClose)
            {
                timer = 0;
                CloseInventory();
            }
        }
    }
    public void CloseInventory()
    {
        LeanTween.cancel(gameObject);
        openByPlayer = false;
        GetComponent<Button>().Select();
        //var closingInventory = LeanTween.sequence();
        //closingInventory.append( LeanTween.moveLocalX(gameObject, -280, (animationTime / 10)));
        //closingInventory.append( LeanTween.delayedCall(animationTime, () => gameObject.SetActive(false)));
        LeanTween.moveLocalX(gameObject, -280, (animationTime / 10)).setOnComplete(() => LeanTween.delayedCall(0.02f, () => gameObject.SetActive(false)));
    }
}
