using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject ajustes;
    public void Continuar()
    {
        menu.SetActive(false);
    }

    public void Ajustes()
    {
        ajustes.SetActive(true);
    }

    public void Salir()
    {
        menu.SetActive(false);
    }
}
