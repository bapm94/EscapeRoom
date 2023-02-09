using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class In_Game_Tool_Data : ScriptableObject
{
    public string Object;
    public Vector3 position;
    public Vector4 quaternionRotation;
    public Sprite sprite;
    public bool isSprite;
}
