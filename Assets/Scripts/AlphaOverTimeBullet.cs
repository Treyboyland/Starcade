using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaOverTimeBullet : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curve = null;

    [SerializeField]
    BulletDataSO bulletData = null;

    [SerializeField]
    SpriteRenderer sprite = null;

    protected float SecondsToChange { get { return bulletData.SecondsToLive; } }

    protected void OnEnable()
    {
        StartCoroutine(ScaleCoroutine());
    }

    protected void SetAlpha(float scale)
    {
        var color = sprite.color;
        color.a = scale;
        sprite.color = color;
    }


    protected IEnumerator ScaleCoroutine()
    {
        SetAlpha(curve.Evaluate(0));

        float elapsed = 0;

        while (elapsed < SecondsToChange)
        {
            elapsed += Time.deltaTime;
            SetAlpha(curve.Evaluate(elapsed / SecondsToChange));
            yield return null;
        }

        SetAlpha(curve.Evaluate(1));
    }
}
