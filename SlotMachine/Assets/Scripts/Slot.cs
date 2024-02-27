using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Slot : MonoBehaviour
{
    public Action<FruitSO> OnSpinComplete;

    [SerializeField] private FruitSO[] _fruitSOs;

    [SerializeField] private Image _imageContainer;

    [SerializeField, Range(0.0f, 1.0f)] private float _timeBetweenChange = 0.02f;

    [Header("Tween Configurations")]
    [SerializeField] private LeanTweenType _tweenType;
    [SerializeField] private float _tweenTime = 0.1f;
    [SerializeField] private float _tweenMoveAmount = -10f;

    private int _tweenId;

    public void Spin(float animationTime)
    {
        _tweenId = LeanTween.moveLocalY(gameObject, _tweenMoveAmount, _tweenTime).setLoopPingPong().setEase(_tweenType).uniqueId;
        StartCoroutine(AnimateSpin(animationTime));
    }

    private IEnumerator AnimateSpin(float animationTime)
    {
        bool isDoingEndTween = false;
        float timeElapsed = 0.0f;
        FruitSO selectedFruit = _fruitSOs[Random.Range(0, _fruitSOs.Length)];

        while (timeElapsed < animationTime)
        {
            int randomFruitSOIdx = Random.Range(0, _fruitSOs.Length);

            selectedFruit = _fruitSOs[randomFruitSOIdx];
            _imageContainer.sprite = selectedFruit.sprite;

            timeElapsed += Time.deltaTime + _timeBetweenChange;

            if (!isDoingEndTween && (animationTime - timeElapsed) < .2f)
            {
                isDoingEndTween = true;
                EndTween();
            }

            yield return new WaitForSeconds(_timeBetweenChange);
        }

        OnSpinComplete?.Invoke(selectedFruit);
    }

    private void EndTween()
    {
        LeanTween.cancel(_tweenId);

        LeanTween.moveLocalY(gameObject, 40f, .2f).setEaseInCirc().setOnComplete(MoveBackTween);
    }

    private void MoveBackTween()
    {
        LeanTween.moveLocalY(gameObject, 0f, .5f).setEaseOutElastic();
    }
}
