using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class letritas : MonoBehaviour
{

    TextMeshProUGUI textHolder;
    TMP_CharacterInfo myCharInfo;
    public TextMeshProUGUI newText;
    char[] jeje;
    bool revelead = false;
    //List<bool> isVisible = new List<bool>();
    bool[] isVisible;
    float[] valoresAlfa;
    private int totalLetters;
    float timer;
    bool canShow = true;
    [SerializeField] float timeBetweenLetter = 0.5f;
    [SerializeField] float velocidad;
    int letersShown = 0;

    CluesController cluesController;

    [SerializeField] public TextMeshProUGUI remainingInsigth;
    [SerializeField] Slider sliderInsigth;
    // Start is called before the first frame update
    void Start()
    {
        cluesController = transform.parent.GetComponent<CluesController>();
        ReloadText();
        remainingInsigth.text = cluesController.insigth.ToString();
        //newText.text = "<alpha=#00>" + textHolder.text;    // 00, 22, 44, 66, 88, AA, CC, FF
    }

    public void ReloadText()
    {
        revelead = false;
        jeje = new char[0];
        totalLetters = 0;
        timer = 0;
        canShow = true;
        letersShown = 0;

        textHolder = GetComponent<TextMeshProUGUI>();
        textHolder.UpdateVertexData();
        jeje = textHolder.text.ToCharArray();
        isVisible = new bool[jeje.Length];
        valoresAlfa = new float[jeje.Length];
        for (int i = 0; i < jeje.Length; i++)
        {
            if (jeje[i].ToString() == " " || jeje[i].ToString() == "," || jeje[i].ToString() == ".")
            {
                //isVisible.Add(true);
                isVisible[i] = true;
                valoresAlfa[i] = 255;
                newText.text += "<alpha=#" + ((byte)valoresAlfa[i]).ToString("X") + ">" + jeje[i].ToString();
                letersShown++;
            }
            else
            {
                //isVisible.Add(false);
                isVisible[i] = false;
                totalLetters++;

                valoresAlfa[i] = 16;

                newText.text += "<alpha=#" + ((byte)valoresAlfa[i]).ToString("X") + ">" + jeje[i].ToString();
            }

        }
        sliderInsigth.maxValue = jeje.Length;
    }
    private void FixedUpdate()
    {
        if (letersShown != jeje.Length) { ImprimirTexto(); }
    }
    private void Update()
    {
        if (!canShow)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenLetter) { timer = 0; canShow = true; }
        }
    }


    private void ImprimirTexto()
    {
        letersShown = 0;
        newText.text = "";
        for (int i = 0; i < jeje.Length; i++)
        {
            if (isVisible[i] == false)
            {
                var text = "<alpha=#00>" + jeje[i].ToString();
                newText.text += text;
            }
            else if (isVisible[i] && valoresAlfa[i] >= 255)
            {
                var text = "<alpha=#FF>" + jeje[i].ToString();
                newText.text += text;
                letersShown ++;
            }
            else if (isVisible[i] && valoresAlfa[i] < 256)
            {
                var text = "<alpha=#" + ((byte)valoresAlfa[i]).ToString("X") + ">" + jeje[i].ToString();
                valoresAlfa[i] += Time.deltaTime * velocidad;
                newText.text += text;
            }            
        }
        
    }

    public void RevealLetter()
    {
        if (!revelead && canShow && cluesController.insigth > 0)
        {
            cluesController.insigth--;
            int random = -1;
            newText.text = "";
            while (random == -1)
            {
                random = ChoseRandom();
            }
            isVisible[random] = true;
            totalLetters -= 1;
            if (totalLetters == 0) { revelead = true; }
            canShow = false; timer = 0;
            sliderInsigth.value++;

            //Actualizar insigth
            remainingInsigth.text = cluesController.insigth.ToString();
        }
        
    }

    private int ChoseRandom()
    {
        int boolIteration = Random.Range(0, jeje.Length);
        if (isVisible[boolIteration])
        {
            boolIteration = -1;
        }
        return boolIteration;
    }
}
