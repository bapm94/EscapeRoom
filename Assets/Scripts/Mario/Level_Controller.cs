using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class Level_Controller : MonoBehaviour
{
    public bool active;
    [SerializeField] Animator b_animator;
    [SerializeField] Animator p_animator;

    public GameObject text;
    Vector3 initialPos;
    [SerializeField] bool textIsOut;

    public bool animCheck;
    public GameObject textCanvas;

    // Start is called before the first frame update
    void Start()
    {
        textCanvas.SetActive(false);
        animCheck = false;
        textIsOut = false;
        initialPos = new Vector3(text.transform.position.x, text.transform.position.y, text.transform.position.z);
        active = false;
        b_animator = this.transform.gameObject.GetComponent<Animator>();
        p_animator = this.transform.parent.GetComponent<Animator>();
    }

    public void BookSelected()
    {
        active = true;
        b_animator.SetTrigger("Shift"); 
        LeanTween.delayedCall(0.2f, () => ResetAllTriggers());
        LeanTween.delayedCall(0.33f, () => TextSlideIn());
    }

    public void BookUnselected()
    {
        b_animator.SetTrigger("Idle");
        LeanTween.delayedCall(0.2f, () => ResetAllTriggers());
        LeanTween.delayedCall(0.33f, () => TextSlideOut());
        active = false;
    }

    public void TextSlideIn()
    {
        LeanTween.moveLocalX(text, -65.0f, 0.5f); textIsOut = true;
    }
    public void TextSlideOut()
    {
        LeanTween.moveLocal(text, initialPos, 0.5f); textIsOut = false;
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
        active = true;
        TextSlideOut();
        p_animator.SetTrigger("MoveToCamera");
        yield return new WaitForSeconds(2.35f);
        b_animator.SetTrigger("Open");
        yield return new WaitForSeconds(1.83f);
        ActivateOrDCanvas();
    }

    public IEnumerator BookReturn()
    {
        b_animator.SetTrigger("Close");
        yield return new WaitForSeconds(0.1f);
        ActivateOrDCanvas();
        yield return new WaitForSeconds(0.56f);
        p_animator.SetTrigger("MoveBack");
        yield return new WaitForSeconds(2.25f);
        BookSelected();
    }

    public void Update()
    {
        if (!active) { p_animator.enabled = false; }
        else { p_animator.enabled = true; }

        //if (!animCheck)
        //{
        //    textCanvas.SetActive(false);
        //}
        //if (!animCheck && b_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f && b_animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|BookOpen"))
        //{
        //    animCheck = true;
        //    textCanvas.SetActive(true);
        //}
    }

    void ActivateOrDCanvas()
    {
        if (textCanvas.activeSelf == false) { textCanvas.SetActive(true); }
        else { textCanvas.SetActive(false); }
    }
}
