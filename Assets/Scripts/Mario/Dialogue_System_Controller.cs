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
    [SerializeField] int rangeMinLocal;
    public string[] names;
    public TextMeshProUGUI characterName;
    public GameObject dialogueParent;
    public Animator animator;
    public AudioSource[] beepSfxs;
    public int whoIsTalking;
    [SerializeField] bool dialogueCheck = false;
    
    Coroutine lastRoutine;

    public static Dialogue_System_Controller instance;

    
    void Start()
    {
        animator = dialogueParent.gameObject.GetComponent<Animator>();

        dialogueParent.SetActive(false);

        if (instance == null) { Dialogue_System_Controller.instance = this; }
        else { Destroy(this); }

        timeBetweenDialogues = 2.5f;
        dialogueSpeed = 0.022f;
    }

    private void OnAction_Button()
    {
        if (!dialogueCheck) { dialogueCheck = true; return; }
        if (dialogueOnGoing && dialogueCheck) { NextSentence(rangeMaxLocal); }
    }
    
    public void GetDialogueInfo(int rangeMin, int rangeMax)
    {
        dialogueCheck = false;
        rangeMaxLocal = rangeMax;
        rangeMinLocal = rangeMin;
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
    }

    void NextSentence(int rangeMax)
    {
        if (dialogueOnGoing && !isTyping)
        {
            if (Index > rangeMax)
            {
                StartCoroutine(DissapearDialogueBox());
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
                StartCoroutine(DissapearDialogueBox());
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
                animator.Play("DialogueBoxSkip");
                Index++;
            }
        }
    }

    IEnumerator DissapearDialogueBox()
    {
        dialogueCheck = false;
        dialogueOnGoing = false;
        animator.Play("DialogueBoxOut");
        yield return new WaitForSeconds(0.8f);
        dialogueParent.SetActive(false);
        if (!Main_Character_Controller_v2.instance.isAnalizingOject) { Main_Camera_Controller.instance.ChangeFollowStatus(true); }
    }

    IEnumerator WriteSentence()
    {
        bool playSfx = false;
        if (rangeMinLocal == Index) { animator.Play("DialogueBox"); }
        else { animator.Play("DialogueBoxSkipStop"); }

        dialogueOnGoing = true;
        isTyping = true;
        char[] Characters = sentences[Index].ToCharArray();
        whoIsTalking = int.Parse(Characters[0].ToString());
        for (int i = 0; i < Characters.Length; i++)
        {
            if (i == 0)
            {
                characterName.text = names[int.Parse(Characters[0].ToString())];
            }
            else
            {
                dialogueText.text += Characters[i];
                playSfx = !playSfx;
                if (playSfx) { beepSfxs[whoIsTalking].pitch = Random.Range(0.8f, 1.2f); beepSfxs[whoIsTalking].Play(); }

                if (Characters[i].ToString() == ",") { yield return new WaitForSeconds(dialogueSpeed + 0.35f); }
                else if (Characters[i].ToString() == "." || Characters[i].ToString() == "?" || Characters[i].ToString() == "!") { yield return new WaitForSeconds(dialogueSpeed + 0.5f); }  
                else { yield return new WaitForSeconds(dialogueSpeed); }
                    
                if (!isTyping) { break; }
            }
        }
        animator.Play("DialogueBoxSkip");
        Index++;
        isTyping = false; 
    }
}
