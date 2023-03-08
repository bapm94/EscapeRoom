using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{

    public bool hasDialogue;
    [SerializeField] bool isInteractable = true;
    [SerializeField] int dialogueBeggining;
    [SerializeField] int dialogueEnd;
    [SerializeField] bool dialogueOnlyOnce;
    [Tooltip("After showing the dialogue the object deactivates its interactability")]
    [SerializeField] bool deactivateAfterDialogue;
    [SerializeField] bool isNotImportant;
    public int localIndex;
    public bool hasDone;
    [SerializeField] Color outlineColor;
    Color notImportantColor = new Color(1.0f, 0.7f, 0.1f, 1.0f);
    Color importantColor = new Color(0.57f, 0.0f, 0.92f, 1.0f);

    //[SerializeField] bool extraActionOnInteraction;
    protected ExtraActionsTemplate extraAction;
    new protected AudioSource audio;

    private void Start()
    {
        gameObject.TryGetComponent<ExtraActionsTemplate>(out ExtraActionsTemplate extra);
        if (extra != null) { extraAction = extra; }

        gameObject.TryGetComponent<AudioSource>(out AudioSource audioSource);
        if (audioSource != null) { audio = audioSource; }
        
        AddToObserversList();
        //gameObject.tag = "000"; gameObject.layer = 6;
    }
    private void Awake()
    {
        SwitchInteractability(true);
          //By default all props are interactable. The code sets the correct tag and layer.
    }

    /// <summary>
    /// This performs the initial dialogue, then the action if true
    /// </summary>
    protected virtual void OnActionButton()  // The action is suscribed to the main interaction controller event.
    {
        gameObject.TryGetComponent<ExtraActionsTemplate>(out ExtraActionsTemplate extra);
        if (extra != null) { extraAction = extra; }
        if (gameObject.layer == 8)  //Only the game object thats being observe will perform the action.
        {
            if (audio != null) { audio.Play(); }
            if (hasDialogue)
            {
                if (dialogueOnlyOnce) { hasDialogue = false; }                
                Dialogue_System_Controller.instance.GetDialogueInfo(dialogueBeggining, dialogueEnd);
                
                if (deactivateAfterDialogue)
                {
                    SwitchInteractability(false);
                }
            }           //If the prop has dialogue to reproduce it does it now
            if (extraAction != null) { extraAction.ExtraActionOnInteraction(); }
        }
    }
    protected virtual void OnBackButton()
    {

    }
    protected virtual void OnInventoryButton()
    {

    }

    public virtual void SwitchInteractability(bool newState)
    {
        if (newState == false)
        {
            
            gameObject.tag = "111"; //gameObject.layer = 0;
            //SubstractFromObserversList();
            isInteractable = false;
            Main_Character_Controller_v2.instance.ChangeSubmeshesLayer(gameObject, 0);
        }
        else
        {
            gameObject.tag = "000"; gameObject.layer = 6;
            //AddToObserversList();
            isInteractable=true;
        }
    }

    public void OutlineColor()
    {
        if (!hasDone)
        {
            hasDone = true;
            if (isNotImportant) { OutlineController.instance.ChangeInteractionColor(notImportantColor); }
            else { OutlineController.instance.ChangeInteractionColor(importantColor); }
        }
    }

    private void OnDestroy()
    {
        SubstractFromObserversList();
    }


    public void AddToObserversList()
    {
        Main_Interacction_Controller.instance.onActionButton -= OnActionButton;
        Main_Interacction_Controller.instance.onBackButton -= OnBackButton;
        Main_Interacction_Controller.instance.onInventoryButton -= OnInventoryButton;
        Main_Interacction_Controller.instance.onActionButton += OnActionButton;  //As interactable it should recive the principal interactión.
        Main_Interacction_Controller.instance.onBackButton += OnBackButton;
        Main_Interacction_Controller.instance.onInventoryButton += OnInventoryButton;
    }
    public void SubstractFromObserversList()
    {
        Main_Interacction_Controller.instance.onActionButton -= OnActionButton;
        Main_Interacction_Controller.instance.onBackButton -= OnBackButton;
        Main_Interacction_Controller.instance.onInventoryButton -= OnInventoryButton;
    }
}
