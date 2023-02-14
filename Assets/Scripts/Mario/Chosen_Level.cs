using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chosen_Level : MonoBehaviour
{
    public bool isCurrentlyActive;
    Animator b_animator;
    public GameObject levelName;
    Vector3 initialPos;

    private void Start()
    {
        initialPos = new Vector3(levelName.transform.localPosition.x, levelName.transform.localPosition.y, levelName.transform.localPosition.z);
        b_animator = this.transform.parent.GetComponent<Animator>();
    }
    public void BookSelected()
    {
        b_animator.SetTrigger("Book1Play");
        LeanTween.moveLocal(levelName, initialPos, 0.5f);
    }

    public void ActiveCheck()
    {
        if (!isCurrentlyActive) { LeanTween.moveLocal(levelName, initialPos, 0.5f); }
    }

    public void TextSlide()
    {
        Debug.Log("working" + isCurrentlyActive);
        if (isCurrentlyActive) { LeanTween.moveLocalX(levelName, -65.0f, 0.5f); }
    }
}
