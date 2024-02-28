using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AppearTween))]
public class PrizeTable : MonoBehaviour
{
    [SerializeField] private GameObject _prizeTableContainer;
    private AppearTween _appearTween;

    private void Awake()
    {
        _appearTween = GetComponent<AppearTween>();
    }

    private void OnEnable()
    {
        _appearTween.TweenAppear(gameObject);
    }

    public void Hide()
    {
        _appearTween.TweenDisappear(gameObject, Disable);
    }

    private void Disable()
    {
        _prizeTableContainer.SetActive(false);
    }
}
