using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBetButton : MonoBehaviour
{
    [SerializeField, Range(1, 50)] private int _betAmount;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => SlotMachineManager.Instance.ChangeBetAmount(_betAmount));
    }
}
