using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRandomizer : MonoBehaviour
{
    [SerializeField]
    ScaleRandomizerData randomizerData = null;

    bool originalScaleStored = false;
    Vector3 originalScale;

    private void OnEnable()
    {
        if (!originalScaleStored)
        {
            originalScaleStored = true;
            originalScale = transform.localScale;
        }
        randomizerData.RandomizeScale(transform, originalScale);
    }
}
