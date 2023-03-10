using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject hud;
    [SerializeField] GameObject hud2;
    [SerializeField] GameObject selected;

    private void OnEnable()
    {
        hud.SetActive(false);
        hud2.SetActive(false);
        LeanTween.delayedCall(2, () => selected.SetActive(true));
    }
}
