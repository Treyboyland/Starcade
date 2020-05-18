using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterParticleFinished : MonoBehaviour
{
    [SerializeField]
    ParticleSystem ps = null;

    private void OnEnable()
    {
        StartCoroutine(DisableAfterDone());
    }

    IEnumerator DisableAfterDone()
    {
        while (ps.isPlaying)
        {
            yield return null;
        }

        while (ps.isEmitting)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
