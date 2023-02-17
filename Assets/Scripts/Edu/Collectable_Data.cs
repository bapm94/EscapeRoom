using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Collectable_Data : ScriptableObject
{
    public Vector3 initialPosition;
    public Vector4 initialQuaternionRotation;
    public Sprite sprite;
    public bool isSprite;
    public bool hasDialog;
    public int dialogBeginning;
    public int dialogEnd;
    public int collectableNumber;
}
