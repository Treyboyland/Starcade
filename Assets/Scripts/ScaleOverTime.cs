using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleOverTime : MonoBehaviour
{
    [SerializeField]
    protected AnimationCurve curve = null;

    [SerializeField]
    float secondsToScale;

    protected virtual float SecondsToScale { get { return secondsToScale; } set { secondsToScale = value; } }

    public UnityEvent OnScaleComplete = new UnityEvent();

    protected void OnEnable()
    {
        StartCoroutine(ScaleCoroutine());
    }

    protected void SetScale(float scale)
    {
        transform.localScale = new Vector3(1, 1, 1) * scale;
    }


    protected IEnumerator ScaleCoroutine()
    {
        SetScale(curve.Evaluate(0));

        float elapsed = 0;

        while (elapsed < SecondsToScale)
        {
            elapsed += Time.deltaTime;
            SetScale(curve.Evaluate(elapsed / SecondsToScale));
            yield return null;
        }

        SetScale(curve.Evaluate(1));
        OnScaleComplete.Invoke();
    }
}
