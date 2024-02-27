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

    public void Spin(float animationTime)
    {
        StartCoroutine(AnimateSpin(animationTime));
    }

    private IEnumerator AnimateSpin(float animationTime)
    {
        float timeElapsed = 0.0f;
        FruitSO selectedFruit = _fruitSOs[Random.Range(0, _fruitSOs.Length)];

        while (timeElapsed < animationTime)
        {
            int randomFruitSOIdx = Random.Range(0, _fruitSOs.Length);

            selectedFruit = _fruitSOs[randomFruitSOIdx];
            _imageContainer.sprite = selectedFruit.sprite;

            timeElapsed += Time.deltaTime + _timeBetweenChange;

            yield return new WaitForSeconds(_timeBetweenChange);
        }

        OnSpinComplete?.Invoke(selectedFruit);
    }
}
