using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCodePuzzle : Prop
{
    [SerializeField] bool numericCode;
    //[SerializeField] string[] codeParts;
    [SerializeField] GameObject[] dials;
    [SerializeField] bool backToPlayerCamAfterVictory = true;


    //int[] codeGiven { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.TryGetComponent<ExtraActionsTemplate>(out ExtraActionsTemplate extra);
        if (extra != null) { extraAction = extra; }

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
            if (backToPlayerCamAfterVictory) { InGame_Menu_Controller.instance.IndexChange(0); }
            Main_Camera_Controller.instance.ChangeFollowStatus(true);
            SwitchInteractability(false);
            if (extraAction != null) { extraAction.ExtraActionOnVictory(); }
        }

    }
}
