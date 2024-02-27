using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Combo", menuName = "Combo")]
public class ComboSO : ScriptableObject
{
    public FruitSO[] Fruits;
    public int Multiplier;
}