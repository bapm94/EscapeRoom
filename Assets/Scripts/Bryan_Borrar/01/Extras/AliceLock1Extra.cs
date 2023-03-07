using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AliceLock1Extra : ExtraActionsTemplate
{
    bool beingInteract = false;
    [SerializeField] GameObject buttonsCanvas;
    [SerializeField] Button firstSelection;
    [SerializeField] GameObject cupboard;

    Material material;
    Color originalMatColor;
    // Start is called before the first frame update
    void Start()
    { 
        material = GetComponent<SkinnedMeshRenderer>().materials[1];
        originalMatColor = material.color;
        Main_Interacction_Controller.instance.onBackButton += OnBackButton;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ExtraActionOnInteraction()
    {
        beingInteract = true;
        InGame_Menu_Controller.instance.IndexChange(2);
        Main_Camera_Controller.instance.ChangeFollowStatus(false);
        LeanTween.delayedCall(1.2f, ()=> buttonsCanvas.SetActive(true));
        firstSelection.Select();
        gameObject.GetComponent<Prop>().SwitchInteractability(false);
        gameObject.layer = 6;
        cupboard.layer = 0;
        cupboard.tag = "111";
        Destroy(cupboard.GetComponent<Prop>());
    }
    public void OnBackButton()
    {
        if (beingInteract == true)
        {
            LeanTween.delayedCall(1.2f, () => buttonsCanvas.SetActive(false));
            beingInteract = false;
            gameObject.GetComponent<Prop>().SwitchInteractability(true);
        }
    }

    public void GlowMaterial()
    {
        Color newColor = new Color(0, 1, 0, 2);
        material.color = newColor;
        Debug.Log(material + "  " + newColor);
    }

}
