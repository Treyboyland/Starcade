using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle = null;

    [SerializeField]
    int updatesBeforeStart = 0;

    Bullet bullet = null;

    /// <summary>
    /// Bullet that this trail should appear behind
    /// </summary>
    public Bullet BulletToTrack
    {
        set
        {
            if (!coroutineStarted)
            {
                bullet = value;
            }

        }
    }

    bool coroutineStarted = false;

    int numUpdates = 0;

    private void OnEnable()
    {
        coroutineStarted = false;
        numUpdates = 0;
        if (bullet != null)
        {
            transform.position = bullet.transform.position;
        }
        particle.Stop();
        particle.Clear();

    }

    // Update is called once per frame
    void Update()
    {
        if (bullet == null)
        {
            return;
        }

        if (bullet.gameObject.activeInHierarchy)
        {
            if (numUpdates > updatesBeforeStart && !particle.isPlaying)
            {
                particle.Play();
            }
            transform.position = bullet.transform.position;
            numUpdates++;
        }
        else if (!coroutineStarted)
        {
            bullet = null;
            coroutineStarted = true;
            StartCoroutine(WaitThenDisable());
        }
        Debug.LogWarning("Is playing: " + particle.isPlaying);
    }
    private void OnDisable()
    {
        coroutineStarted = false;
    }

    IEnumerator WaitThenDisable()
    {
        particle.Stop();
        while (particle.particleCount != 0)
        {
            yield return null;
        }
        yield return new WaitForSeconds(5.0f);

        gameObject.SetActive(false);
    }
}
