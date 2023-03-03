using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_Text_Controller : MonoBehaviour
{
    public bool hasDialogue;
    public bool activateDialogueOnce;
    public bool advancesTutorials;
    public int tutorialAdvanced;
    public bool endsOtherTutorials;
    public int tutorialNumber;
    public int dialogueStart;
    public int dialogueEnd;

    public void OnTriggerEnter(Collider other)
    {
        if (hasDialogue)
        {
            if (other.gameObject.layer == 14)
            {
                Debug.Log("storyelement");
                Dialogue_System_Controller.instance.GetDialogueInfo(dialogueStart, dialogueEnd);
                Dialogue_System_Controller.instance.dialogueCheck = true;
                if (activateDialogueOnce) { hasDialogue = false; this.gameObject.SetActive(false); }
                if (endsOtherTutorials) { Tutorial_Manager.instance.EndTutorials(tutorialAdvanced); }
                if (advancesTutorials) { Tutorial_Manager.instance.AdvanceTutorial(tutorialAdvanced); }
            }
        }
    }
}
