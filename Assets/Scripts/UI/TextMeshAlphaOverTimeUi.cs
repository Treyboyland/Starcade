using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshAlphaOverTimeUi : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textBox = null;

    [SerializeField]
    AnimationCurve alphaCurve = null;

    [SerializeField]
    float secondsPerLoop = 0;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(CycleAlpha());
        }
    }

    void SetAlpha(float alpha)
    {
        var color = textBox.color;
        color.a = alpha;
        textBox.color = color;
    }

    IEnumerator CycleAlpha()
    {
        float elapsed = 0;
        while (true)
        {
            elapsed += Time.deltaTime;
            SetAlpha(alphaCurve.Evaluate(elapsed / secondsPerLoop));
            yield return null;
        }
    }
}
