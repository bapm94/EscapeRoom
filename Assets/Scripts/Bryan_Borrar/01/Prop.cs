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
    public int localIndex;

    private void Start()
    {
        AddToObserversList();
        //gameObject.tag = "000"; gameObject.layer = 6;
    }
    private void Awake()
    {
        gameObject.tag = "000"; gameObject.layer = 6;  //By default all props are interactable. The code sets the correct tag and layer.
    }


    //private void OnEnable()
    //{

    //    gameObject.tag = "000"; gameObject.layer = 6;  //By default all props are interactable. The code sets the correct tag and layer.
       
        
    //}


    /// <summary>
    /// This performs the initial dialogue, then the action if true
    /// </summary>
    protected virtual void OnActionButton()  // The action is suscribed to the main interaction controller event.
    {        
        if (gameObject.layer == 8)  //Only the game object thats being observe will perform the action.
        {
            if (hasDialogue)
            {
                if (dialogueOnlyOnce) { hasDialogue = false; }                
                Dialogue_System_Controller.instance.GetDialogueInfo(dialogueBeggining, dialogueEnd);
                if (deactivateAfterDialogue)
                {
                    SwitchInteractability(false);
                }
            }           //If the prop has dialogue to reproduce it does it now
            
        }
    }
    protected virtual void OnBackButton()
    {

    }
    protected virtual void OnInventoryButton()
    {

    }

    protected virtual void SwitchInteractability(bool newState)
    {
        if (newState == false)
        {
            
            gameObject.tag = "111"; //gameObject.layer = 0;
            SubstractFromObserversList();
            isInteractable = false;
        }
        else
        {
            gameObject.tag = "000"; //gameObject.layer = 6;
            AddToObserversList();
            isInteractable=true;
        }
    }
    private void OnDestroy()
    {
        SubstractFromObserversList();
    }
    private void OnDisable()
    {
        SubstractFromObserversList();
    }

    protected void AddToObserversList()
    {

        Main_Interacction_Controller.instance.onActionButton += OnActionButton;  //As interactable it should recive the principal interactión.
        Main_Interacction_Controller.instance.onBackButton += OnBackButton;
        Main_Interacction_Controller.instance.onInventoryButton += OnInventoryButton;
    }
    protected void SubstractFromObserversList()
    {
        Main_Interacction_Controller.instance.onActionButton -= OnActionButton;
        Main_Interacction_Controller.instance.onBackButton -= OnBackButton;
        Main_Interacction_Controller.instance.onInventoryButton -= OnInventoryButton;
    }
}
