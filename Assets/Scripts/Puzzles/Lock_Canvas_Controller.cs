using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lock_Canvas_Controller : MonoBehaviour
{
    [SerializeField] string solvingCode;
    TMP_Dropdown[] codeNumbers;
    int[] code;
    public GameObject _3dLock { get; set; }
    //int[] Code;
    // Start is called before the first frame update
    void Start()
    {
        codeNumbers = new TMP_Dropdown[transform.childCount];
        code = new int[codeNumbers.Length];
        for (int i = 0; i < codeNumbers.Length; i++)
        {
            codeNumbers[i] = transform.GetChild(i).GetComponent<TMP_Dropdown>();
        }
    }

    private void OnBack_Button()
    {
        Main_Camera_Controller.instance.ChangeFollowStatus(true);
        gameObject.SetActive(false);
    }
    public string GetCode()
    {
        string output = "" ;
        for (int i = 0; i < codeNumbers.Length; i++)
        {
            code[i] = codeNumbers[i].value;
            output += code[i].ToString();
        }
        return output;
        
    }
    public void Proof()
    {
        
        Debug.Log(GetCode());
        if (solvingCode == GetCode())
        {
            gameObject.SetActive(false);
            Main_Camera_Controller.instance.ChangeFollowStatus(true);
            Debug.Log("Solved");
            Destroy(_3dLock);
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
    
}
