using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Dialogue_System_Controller : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    [SerializeField] int Index = 0;
    public float dialogueSpeed;
    public float timeBetweenDialogues;
    public bool dialogueOnGoing;
    [SerializeField] bool isTyping;
    [SerializeField] int rangeMaxLocal;
    public string[] names;
    public TextMeshProUGUI characterName;
    public GameObject dialogueParent;

    //public AnimationClip fadeOut;
    //Animation anim;
    
    Coroutine lastRoutine;

    public static Dialogue_System_Controller instance;


    void Start()
    {
        /*anim = GetComponent<Animation>();
        anim.clip = fadeOut;*/

        dialogueParent.SetActive(false);

        if (instance == null) { Dialogue_System_Controller.instance = this; }
        else { Destroy(this); }

        timeBetweenDialogues = 2.5f;
        dialogueSpeed = 0.022f;
    }

    private void OnAction_Button()
    {
        if (dialogueOnGoing)
        {
            NextSentence(rangeMaxLocal);
        }
    }
    
    public void GetDialogueInfo(int rangeMin, int rangeMax)
    {
        rangeMaxLocal = rangeMax;
        Main_Camera_Controller.instance.ChangeFollowStatus(false);

        if (!dialogueOnGoing)
        {
            dialogueParent.SetActive(true);
            StartDialogue(rangeMin);
        }
        else { NextSentence(rangeMaxLocal); }
    }

    void StartDialogue(int rangeMin)
    {
        Index = rangeMin;
        dialogueText.text = "";
        lastRoutine = null;
        lastRoutine = StartCoroutine(WriteSentence());
        dialogueOnGoing = true;
    }

    void NextSentence(int rangeMax)
    {
        if (dialogueOnGoing && !isTyping)
        {
            if (Index > rangeMax)
            {
                //anim.Play();
                dialogueOnGoing = false;
                dialogueParent.SetActive(false);
                if (!Main_Character_Controller_v2.instance.isAnalizingOject) { Main_Camera_Controller.instance.ChangeFollowStatus(true); }
            }
            else
            {
                dialogueText.text = "";
                lastRoutine = null;
                lastRoutine = StartCoroutine(WriteSentence());
            }
        }
        else if (dialogueOnGoing && isTyping)
        {
            if (Index > rangeMax) 
            {
                //anim.Play();
                dialogueOnGoing = false; 
                dialogueParent.SetActive(false);
                if (!Main_Character_Controller_v2.instance.isAnalizingOject) { Main_Camera_Controller.instance.ChangeFollowStatus(true); }
            }
            else
            {
                StopCoroutine(lastRoutine);
                dialogueText.text = "";
                char[] temp = sentences[Index].ToCharArray();
                isTyping = false;
                for (int i = 1; i < temp.Length; i++)
                {
                    dialogueText.text += temp[i];
                }
                Index++;
            }
        }
    }


    IEnumerator WriteSentence()
    {
        isTyping = true;
        char[] Characters = sentences[Index].ToCharArray();
        for (int i = 0; i < Characters.Length; i++)
        {
            if (i == 0)
            {
                characterName.text = names[int.Parse(Characters[0].ToString())];
            }
            else
            {
                dialogueText.text += Characters[i];

                if (Characters[i].ToString() == ",") { yield return new WaitForSeconds(dialogueSpeed + 0.35f); }
                else if (Characters[i].ToString() == ".") { yield return new WaitForSeconds(dialogueSpeed + 0.5f); }  
                else { yield return new WaitForSeconds(dialogueSpeed); }
                    
                if (!isTyping) { break; }
            }
        }
        Index++;
        isTyping = false; 
    }
}
