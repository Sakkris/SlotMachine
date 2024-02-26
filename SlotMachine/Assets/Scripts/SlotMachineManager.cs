using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotMachineManager : MonoBehaviour
{
    public static SlotMachineManager Instance {get; private set;}

    [Header("Slots")]
    [SerializeField] private Slot[] _slots;
    [SerializeField, Range(0.0f, 5.0f)] private float _animationTime = 1.0f;
    [SerializeField, Range(0.0f, 5.0f)] private float _animationDiffTime = .2f;

    [Header("Gambling")]
    [SerializeField, Range(0.0f, 5.0f)] private int _playerCredits;
    [SerializeField, Range(0.0f, 5.0f)] private int _betAmount;

    [Header("Interface")]
    [SerializeField] private TextMeshProUGUI _creditsText;
    [SerializeField] private TextMeshProUGUI _betText;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        UpdateBetText();
    }

    public void SpinAll()
    {
        float slotAnimationTime = _animationTime;

        foreach (Slot slot in _slots)
        {
            slot.Spin(slotAnimationTime);

            slotAnimationTime += _animationDiffTime;
        }
    }


    public void ChangeBetAmount(int bet)
    {
        _betAmount = bet;
        UpdateBetText();
    }

    public void UpdateBetText()
    {
        _betText.text = string.Format("Bet:\n{0}", _betAmount);
    }

    public void AddCredits(int credits)
    {
        _playerCredits += credits;
        UpdateCreditsText();
    }

    public void UpdateCreditsText()
    {
        _creditsText.text = string.Format("Credits:\n{0}", _playerCredits);
    }
}