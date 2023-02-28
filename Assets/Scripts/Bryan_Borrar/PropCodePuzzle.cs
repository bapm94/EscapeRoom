using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCodePuzzle : Prop
{
    [SerializeField] bool numericCode;
    //[SerializeField] string[] codeParts;
    [SerializeField] GameObject[] dials;
    //int[] codeGiven { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //codeGiven = new int[codeParts.Length];

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckForVictory()
    {
        int victoryCount = 0;
        for (int i = 0; i < dials.Length; i++)
        {
            dials[i].TryGetComponent<RotationOnDrag>(out RotationOnDrag rotationOnDrag);
            if (rotationOnDrag.victory)
            {
                victoryCount++;
            }
        }

        if (victoryCount == dials.Length)
        {
            Debug.Log("VICTORIA");
        }

    }
}
