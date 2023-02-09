using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class In_Game_Tool_Data : ScriptableObject
{
    public Vector3 initialPosition;
    public Vector4 initialQuaternionRotation;
    public Sprite sprite;
    public bool isSprite;
}
