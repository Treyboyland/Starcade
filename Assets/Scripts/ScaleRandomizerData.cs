using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScaleData")]
public class ScaleRandomizerData : ScriptableObject
{
    [SerializeField]
    AnimationCurve curve = null;

    [SerializeField]
    Vector2 scaleMultiplierRange = new Vector2();

    public void RandomizeScale(Transform transform, Vector3 originalSize)
    {
        transform.localScale = originalSize * Mathf.Lerp(scaleMultiplierRange.x, scaleMultiplierRange.y,
            curve.Evaluate(Random.Range(0.0f, 1.0f)));
    }
}
