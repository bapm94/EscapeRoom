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

    [SerializeField] bool desapearingLock;
    [SerializeField] bool moveParts;
    [SerializeField] GameObject[] partsToMove;
    [SerializeField] GameObject[] newPartsPosition;
    bool[] partMoved;
    //int[] Code;
    // Start is called before the first frame update
    void Start()
    {
        partMoved = new bool[partsToMove.Length];
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
            if (desapearingLock) { Destroy(_3dLock); }
            if (moveParts) { MoveAll(); }
            Main_Character_Controller_v2.instance.PerceivedGO.layer = 0;
            Main_Character_Controller_v2.instance.PerceivedGO.tag = "Untagged";
        }
        else
        {
            Debug.Log("Wrong");
        }
    }

    public void MovePart(int x)
    {
        LeanTween.move(partsToMove[x], newPartsPosition[x].transform.position, 2f);
        LeanTween.rotate(partsToMove[x], newPartsPosition[x].transform.eulerAngles, 2f);
        partMoved[x] = true;
    }
    public void MoveAll()
    {
        for (int i = 0; i < partsToMove.Length; i++)
        {
            MovePart(i);
        }
    }
}
