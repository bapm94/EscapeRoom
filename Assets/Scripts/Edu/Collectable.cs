using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public In_Game_Tool_Data GameobjectData;
    public int element_Local_Index { get; set; }

    Vector3 position;
    Vector4 quaternionRotation;
    public Sprite sprite { get; set; }
    public bool isSprite { get; set; }
    public bool hasDialog { get; set; }
    public int dialogBeginning { get; set; }
    public int dialogEnd { get; set; }

    public int collectableNumber { get; set; }

    public void Start()
    {
        position = GameobjectData.initialPosition;
        quaternionRotation = GameobjectData.initialQuaternionRotation;
        sprite = GameobjectData.sprite;
        isSprite = GameobjectData.isSprite;
        hasDialog = GameobjectData.hasDialog;
        dialogBeginning = GameobjectData.dialogBeginning;
        dialogEnd = GameobjectData.dialogEnd;
        collectableNumber = GameobjectData.collectableNumber;
    }

    public void GrabIt()
    {
        isSprite = true;

    }
}
