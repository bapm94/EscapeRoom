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
    bool dialogueOnGoing;
    bool isTyping;

    void Start()
    {
        dialogueSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GetDialogueInfo(0, 1);
        }
    }

    public void GetDialogueInfo(int rangeMin, int rangeMax)
    {
        if (!isTyping)
        {
            if (!dialogueOnGoing)
                StartDialogue(rangeMin);
            else
                NextSentence(rangeMax);
        }
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
        if (dialogueOnGoing)
        {
            if (Index > rangeMax)
            {
                dialogueOnGoing = false;
            }
            else
            {
                if (Index < sentences.Length)
                {
                    dialogueText.text = "";
                    StartCoroutine(WriteSentence());
                }
            }
        }
    }

    IEnumerator WriteSentence()
    {
        isTyping = true;
        foreach (char Character in sentences[Index].ToCharArray())
        {
            dialogueText.text += Character;
            yield return new WaitForSeconds(dialogueSpeed);
        }
        Index++;
        isTyping = false;
        Debug.Log("HOLA");
    }
}
