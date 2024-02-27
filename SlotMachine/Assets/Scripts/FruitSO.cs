using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fruit", menuName = "Fruit")]
public class FruitSO : ScriptableObject
{
    public int fruitCode;
    public Sprite sprite;
}
