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
    List<bool> isVisible = new List<bool>();
    private int totalLetters;
    // Start is called before the first frame update
    void Start()
    {
        textHolder = GetComponent<TextMeshProUGUI>();
        textHolder.UpdateVertexData();
        jeje = textHolder.text.ToCharArray();
        
        for (int i = 0; i < jeje.Length; i++)
        {
            isVisible.Add(false);
        }
        totalLetters = jeje.Length;
        newText.text = "<alpha=#00>" + textHolder.text;    // 00, 22, 44, 66, 88, AA, CC, FF
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            int random = -1;
            newText.text = "";
            while (random == -1  && totalLetters !=0)
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
