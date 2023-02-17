using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Level_Controller : MonoBehaviour
{
    public bool active;
    [SerializeField] Animator b_animator;
    [SerializeField] Animator p_animator;

    public GameObject text;
    Vector3 initialPos;
    [SerializeField] bool textIsOut;

    // Start is called before the first frame update
    void Start()
    {
        textIsOut = false;
        initialPos = new Vector3(text.transform.position.x, text.transform.position.y, text.transform.position.z);
        active = false;
        b_animator = GetComponent<Animator>();
        p_animator = this.transform.parent.GetComponent<Animator>();
    }

    public void BookSelected()
    {
        active = true;
        b_animator.SetTrigger("Shift"); 
        LeanTween.delayedCall(0.2f, () => ResetAllTriggers());
        LeanTween.delayedCall(0.33f, () => TextSlide());
    }

    public void BookUnselected()
    {
        active = false;
        b_animator.SetTrigger("Idle");
        LeanTween.delayedCall(0.2f, () => ResetAllTriggers());
        LeanTween.delayedCall(0.33f, () => TextSlide());
    }

    public void TextSlide()
    {
        if (!textIsOut) { LeanTween.moveLocalX(text, -65.0f, 0.5f); textIsOut = true; }
        else { LeanTween.moveLocal(text, initialPos, 0.5f); textIsOut = false; }
    }

    public void ResetAllTriggers()
    {
        foreach (var parameter in b_animator.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Trigger)
            {
                b_animator.ResetTrigger(parameter.name);
            }
        }
    }

    public IEnumerator BookDisplay()
    {
        TextSlide();
        p_animator.SetTrigger("MoveToCamera");
        yield return new WaitForSeconds(2.35f);
        b_animator.SetTrigger("Open");
    }

    public IEnumerator BookReturn()
    {
        b_animator.SetTrigger("Close");
        yield return new WaitForSeconds(1.2f);
        p_animator.SetTrigger("MoveBack");
        yield return new WaitForSeconds(2.25f);
        BookSelected();
    }
}
