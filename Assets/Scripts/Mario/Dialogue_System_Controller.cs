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
    public string[] names;
    public TextMeshProUGUI characterName;
    public GameObject dialogueParent;

    public static Dialogue_System_Controller instance;


    void Start()
    {
        if (instance == null)
            Dialogue_System_Controller.instance = this;
        else
            Destroy(this);

        timeBetweenDialogues = 2.5f;
        dialogueSpeed = 0.022f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            GetDialogueInfo(0, 3);
        }*/

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            NextSentence(rangeMaxLocal);
        }

        if (!dialogueOnGoing)
            dialogueParent.SetActive(false);
        else
            dialogueParent.SetActive(true);
    }

    public void GetDialogueInfo(int rangeMin, int rangeMax)
    {
        rangeMaxLocal = rangeMax;
        Main_Camera_Controller.instance.ChangeFollowStatus(false);

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
                Main_Camera_Controller.instance.ChangeFollowStatus(true);
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
        else if (dialogueOnGoing && isTyping)
        {
            if (Index > rangeMax)
            {
                dialogueOnGoing = false;
            }
            else
            {
                dialogueText.text = "";
                char[] temp = sentences[Index].ToCharArray();
                isTyping = false;
                for (int i = 1; i < temp.Length; i++)
                {
                    dialogueText.text += temp[i];
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
                characterName.text = names[int.Parse(Characters[0].ToString())];
            }
            else
            {
                dialogueText.text += Characters[i];
                yield return new WaitForSeconds(dialogueSpeed);
                if (!isTyping)
                {
                    break;
                }
            }
        }
        Index++;
        isTyping = false; 
    }
}
