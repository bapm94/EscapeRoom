using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CluesController : MonoBehaviour
{
    public static CluesController instance;
    GameObject textObject;
    TextMeshProUGUI textMeshProUGUI;
    [SerializeField] string[] clues;
    public int insigth = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this); }
        textObject = transform.GetChild(1).gameObject;
        textMeshProUGUI = textObject.GetComponent<TextMeshProUGUI>();
        if (clues.Length > 0) { ChangeClue(0); }
        //ChangeClue(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeClue(int x)
    {       
        textMeshProUGUI.text = clues[x];
        textObject.GetComponent<letritas>().ReloadText();
    }
}
