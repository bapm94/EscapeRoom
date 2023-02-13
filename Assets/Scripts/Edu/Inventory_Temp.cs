using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Temp : MonoBehaviour
{
    string[] puzzles;
    bool[] resolved;
    float[] resolutionTime;
    int[] insight;



    public bool openByPlayer;
    float timer;
    [SerializeField] float timeToClose = 3;

    public GameObject[] prop;
    public List<GameObject> propsGrabbed = new List<GameObject>();

    void Start()
    {
        for(int i = 0 ; i < prop.Length; i++)
        {
            prop[i].GetComponent<In_Game_Tool>().element_Local_Index = i;
        }
    }

    private void OnEnable()
    {
        
    }


    private void Update()
    {
        if (!openByPlayer)
        {
            timer += Time.deltaTime;
        }
    }

}
