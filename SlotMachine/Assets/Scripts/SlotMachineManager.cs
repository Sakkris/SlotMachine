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

    [Header("Interface")]
    [SerializeField] private TextMeshProUGUI _creditsText;
    [SerializeField] private TextMeshProUGUI _betText;

    private int _playerCredits;
    private int _betAmount;

    private List<FruitSO> _selectedFruitsList;
    private int _completedSlots;
    private bool _isSpinning;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _playerCredits = 0;
        _betAmount = 5;
        _isSpinning = false;

        UpdateBetText();
    }

    private void Start()
    {
        foreach (Slot slot in _slots)
        {
            slot.OnSpinComplete += SlotSpinCompleted;
        }

        _selectedFruitsList = new List<FruitSO>();
    }

    private void OnDisable()
    {
        foreach (Slot slot in _slots)
        {
            slot.OnSpinComplete -= SlotSpinCompleted;
        }
    }

    public void SpinAll()
    {
        if (_isSpinning || _playerCredits < _betAmount)
            return;

        _playerCredits -= _betAmount;
        UpdateCreditsText();

        _completedSlots = 0;
        _isSpinning = true;

        float slotAnimationTime = _animationTime;

        foreach (Slot slot in _slots)
        {
            slot.Spin(slotAnimationTime);

            slotAnimationTime += _animationDiffTime;
        }
    }

    private void SlotSpinCompleted(FruitSO fruitSO)
    {
        if (_selectedFruitsList == null)
        {
            _selectedFruitsList = new List<FruitSO> { fruitSO };
        }
        else
        {
            _selectedFruitsList.Add(fruitSO);
        }

        _completedSlots++;

        if (_completedSlots == _slots.Length)
        {
            _isSpinning = false;
            CalculateWin();
        }

    }

    private void CalculateWin()
    {
        Debug.Log("Here");
        _selectedFruitsList.Clear();
    }

    public void ChangeBetAmount(int bet)
    {
        if (_isSpinning) return;

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