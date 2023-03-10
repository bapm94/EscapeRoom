using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject hud;
    [SerializeField] GameObject hud2;

    private void OnEnable()
    {
        hud.SetActive(false);
        hud2.SetActive(false);
    }
}
