using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineManager : MonoBehaviour
{
    [SerializeField] private Slot[] _slots;
    [SerializeField, Range(0.0f, 5.0f)] private float _animationTime = 1.0f;
    [SerializeField, Range(0.0f, 5.0f)] private float _animationDiffTime = .2f;

    public void SpinAll()
    {
        float slotAnimationTime = _animationTime;

        foreach (Slot slot in _slots)
        {
            slot.Spin(slotAnimationTime);

            slotAnimationTime += _animationDiffTime;
        }
    }

}