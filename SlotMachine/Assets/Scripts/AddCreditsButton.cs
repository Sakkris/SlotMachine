using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCreditsButton : MonoBehaviour
{
    [SerializeField, Range(1, 50)] private int _creditsAmount;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => SlotMachineManager.Instance.AddCredits(_creditsAmount));
    }
}
