using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBetButton : MonoBehaviour
{
    [SerializeField, Range(1, 50)] private int _betAmount;
    [SerializeField] private bool _isSelected = false;
    

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => SlotMachineManager.Instance.ChangeBetAmount(_betAmount));

        if (_isSelected)
        {
            SlotMachineManager.Instance.ChangeBetAmount(_betAmount);
            TweenSelected();
        }
    }

    public void TweenSelected()
    {
        LeanTween.scale(gameObject, new Vector3(1.4f, 1.4f, 1.4f), 0.2f).setEaseInOutSine();
        LeanTween.moveLocalY(gameObject, 60.0f, 0.2f).setEaseInOutSine();

        _isSelected = true;
    }

    public void TweenDeselected()
    {
        if (!_isSelected) return;

        LeanTween.scale(gameObject, Vector3.one, 0.2f).setEaseInOutSine();
        LeanTween.moveLocalY(gameObject, 0.0f, 0.2f).setEaseInOutSine();

        _isSelected = false;
    }
}
