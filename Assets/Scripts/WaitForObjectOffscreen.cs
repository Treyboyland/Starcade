using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForObjectOffscreen : MonoBehaviour
{
    [SerializeField]
    Renderer objectToWaitFor = null;

    [SerializeField]
    float minSecondsToWait = 0;

    [SerializeField]
    float maxSecondsToWait = 0;

    [SerializeField]
    GameEvent EscapeComplete = null;

    public void WaitForEscape()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        float elapsed = 0;
        while (elapsed < maxSecondsToWait && objectToWaitFor.isVisible)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(minSecondsToWait);

        EscapeComplete.RaiseEvent();
    }
}
