using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBeforeEscape : MonoBehaviour
{
    [SerializeField]
    float secondsToWait = 0;

    [SerializeField]
    GameEvent playerEscapeEvent = null;

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerShip>();
        if (player != null)
        {
            StopAllCoroutines();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerShip>();
        if (player != null)
        {
            StartCoroutine(WaitThenEscape());
        }
    }

    IEnumerator WaitThenEscape()
    {
        yield return new WaitForSeconds(secondsToWait);
        playerEscapeEvent.RaiseEvent();
    }
}
