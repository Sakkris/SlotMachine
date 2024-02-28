using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearTween : MonoBehaviour
{
    [SerializeField] private float _tweenTime = 0.5f;
    [SerializeField] private LeanTweenType _tweenType;

    public void TweenAppear(GameObject target, Action onCompleteAction = null)
    {
        target.transform.localScale = new Vector3(0, 0, 0);

        LeanTween.scale(target, Vector3.one, _tweenTime).setEase(_tweenType).setIgnoreTimeScale(true).setOnComplete(onCompleteAction); 
    }

    public void TweenDisappear(GameObject target, Action onCompleteAction = null)
    {
        LeanTween.scale(target, Vector3.zero, _tweenTime).setEase(_tweenType).setIgnoreTimeScale(true).setOnComplete(onCompleteAction);
    }
}
