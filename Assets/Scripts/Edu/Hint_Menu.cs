using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_Menu : MonoBehaviour
{
    List<bool> puzzle = new List<bool>(); //Se entiende que todos los bool de la lista empiezan en false
    List<GameObject> hint = new List<GameObject>();
    List<int> hintCost = new List<int>();
    public int actualHint; //La pista del puzzle m�s pr�ximo a resolver
    public int insight { get; set; } //Deber�a de tomarse este valor del script de datos de la partida
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void RefreshHints() //Funci�n para el bot�n de abrir men� de pistas
    {
        for (int i = 0; puzzle[i] == false; i++)
        {
            if (puzzle[i] == false)
            {
                actualHint = i;
            }
        }
    }

    public void BuyHint()
    {
        if(insight >= hintCost[actualHint])
        {
            hint[actualHint].SetActive(true);
        }

        else
        {
            Debug.Log("Not enought insight");
        }
        
    }

}
