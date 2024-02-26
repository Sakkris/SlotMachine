using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Slot : MonoBehaviour
{
    [SerializeField] private FruitSO[] _fruitSprites;

    [SerializeField] private Image _imageContainer;

    [SerializeField, Range(0.0f, 1.0f)] private float _timeBetweenChange = 0.02f;

    [Header("Bet")]
    [SerializeField] private TextMeshProUGUI _betText;

    public void Spin(float animationTime)
    {
        StartCoroutine(AnimateSpin(animationTime));
    }

    private IEnumerator AnimateSpin(float animationTime)
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < animationTime)
        {
            int randomSpriteIdx = Random.Range(0, _fruitSprites.Length);

            _imageContainer.sprite = _fruitSprites[randomSpriteIdx].sprite;

            timeElapsed += Time.deltaTime + _timeBetweenChange;

            yield return new WaitForSeconds(_timeBetweenChange);
        }
    }

    public void UpdateBetAmount(int betAmount)
    {
        _betText.text = string.Format("Bet:\n{0}", betAmount.ToString());
    }
}
