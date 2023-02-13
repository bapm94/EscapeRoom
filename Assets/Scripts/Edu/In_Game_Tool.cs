using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_Game_Tool : MonoBehaviour
{
    public In_Game_Tool_Data GameobjectData;
    public int element_Local_Index { get; set; }

    Vector3 position;
    Vector4 quaternionRotation;
    public Sprite sprite { get; set; }
    public bool isSprite { get; set; }
    public bool hasDialogue { get; set; }
    public int dialogueBeginning { get; set; }
    public int dialogueEnd { get; set; }

    public void Start()
    {
        position = GameobjectData.initialPosition;
        quaternionRotation = GameobjectData.initialQuaternionRotation;
        sprite = GameobjectData.sprite;
        isSprite = GameobjectData.isSprite;
        hasDialogue = GameobjectData.hasDialog;
        dialogueBeginning = GameobjectData.dialogBeginning;
        dialogueEnd = GameobjectData.dialogEnd;
    }
}
