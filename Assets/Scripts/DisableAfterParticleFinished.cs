using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterParticleFinished : MonoBehaviour
{
    [SerializeField]
    ParticleSystem ps = null;

    [SerializeField]
    List<ParticleSystem> particleSystems = null;

    private void OnEnable()
    {
        StartCoroutine(DisableAfterDone());
    }

    public void SetColor(Color c)
    {
        foreach (var particle in particleSystems)
        {
            var main = particle.main;
            main.startColor = c;
        }
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
