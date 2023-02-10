using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class letritas : MonoBehaviour
{

    TextMeshProUGUI textHolder;
    TMP_CharacterInfo myCharInfo;
    public TextMeshProUGUI newText;
    char[] jeje;
    bool revelead = false;
    List<bool> isVisible = new List<bool>();
    private int totalLetters;
    float timer;
    bool canShow = true;
    [SerializeField] float timeBetweenLetter = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        textHolder = GetComponent<TextMeshProUGUI>();
        textHolder.UpdateVertexData();
        jeje = textHolder.text.ToCharArray();
        
        for (int i = 0; i < jeje.Length; i++)
        {
            if (jeje[i].ToString() == " " || jeje[i].ToString() == "," || jeje[i].ToString() == ".")
            {
                isVisible.Add(true);
                newText.text += "<alpha=#FF>" + jeje[i].ToString();
            }
            else
            {
                isVisible.Add(false);
                totalLetters ++;

                newText.text += "<alpha=#00>" + jeje[i].ToString();
            }
            
        }
        
        //newText.text = "<alpha=#00>" + textHolder.text;    // 00, 22, 44, 66, 88, AA, CC, FF
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShow)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetweenLetter) { timer = 0; canShow = true; }            
        }  
        if (Keyboard.current.lKey.isPressed)
        {
            RevealLetter();
        }

    }

    private void RevealLetter()
    {
        if (!revelead && canShow)
        {
            int random = -1;
            newText.text = "";
            while (random == -1)
            {
                random = ChoseRandom();
            }
            isVisible[random] = true;
            totalLetters -= 1;
            for (int i = 0; i < jeje.Length; i++)
            {
                if (isVisible[i] == false)
                {
                    newText.text += "<alpha=#00>" + jeje[i].ToString();
                }
                else
                {
                    newText.text += "<alpha=#FF>" + jeje[i].ToString();
                }
            }
            if (totalLetters == 0) { revelead = true; }
            canShow = false; timer = 0;
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
