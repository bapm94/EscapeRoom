using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Dialogue_System_Controller : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    int Index = 0;
    public float dialogueSpeed;
    public float timeBetweenDialogues;
    bool dialogueOnGoing;
    [SerializeField] bool isTyping;
    int rangeMaxLocal;
    [SerializeField] bool hasChangedSentence;
    [SerializeField] bool coroutineRunning;

    void Start()
    {
        coroutineRunning = false;
        timeBetweenDialogues = 2.5f;
        dialogueSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            GetDialogueInfo(0, 3);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            NextSentence(rangeMaxLocal);
        }
    }

    public void GetDialogueInfo(int rangeMin, int rangeMax)
    {
        rangeMaxLocal = rangeMax;

        if (!dialogueOnGoing)
            StartDialogue(rangeMin);
        else
            NextSentence(rangeMaxLocal);        
    }

    void StartDialogue(int rangeMin)
    {
        Index = rangeMin;
        dialogueText.text = "";
        StartCoroutine(WriteSentence());
        dialogueOnGoing = true;
    }

    void NextSentence(int rangeMax)
    {
        if (dialogueOnGoing && !isTyping)
        {
            if (Index > rangeMax)
            {
                dialogueOnGoing = false;
            }
            else
            {
                if (Index < sentences.Length)
                {
                    hasChangedSentence = true;
                    dialogueText.text = "";
                    StartCoroutine(WriteSentence());
                }
            }
        }
        else if (dialogueOnGoing && isTyping)
        {
            if (Index > rangeMax)
            {
                hasChangedSentence = true;
                dialogueOnGoing = false;
            }
            else
            {
                if (Index < sentences.Length)
                {
                    hasChangedSentence = true;
                    isTyping = false;
                    dialogueText.text = sentences[Index];
                }
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

            }
            else
            {
                dialogueText.text += Characters[i];
                yield return new WaitForSeconds(dialogueSpeed);
                if (!isTyping)
                {
                    hasChangedSentence = true;
                    break;
                }
            }
        }

        /*foreach (char Character in Characters)
        {
            dialogueText.text += Character;
            yield return new WaitForSeconds(dialogueSpeed);
            if (!isTyping)
            {
                hasChangedSentence = true;
                break;
            }
        }*/

        Index++;
        isTyping = false; 
    }

    //HOLA QUE TAL
}
