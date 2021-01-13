using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathUiController : MonoBehaviour
{
    [SerializeField]
    float secondsToWait = 0;

    [SerializeField]
    GameObject deathCanvas = null;

    // Start is called before the first frame update
    void Start()
    {
        deathCanvas.SetActive(false);
    }

    public void ShowCanvas()
    {
        StartCoroutine(WaitThenShow());
    }

    IEnumerator WaitThenShow()
    {
        yield return new WaitForSeconds(secondsToWait);
        deathCanvas.gameObject.SetActive(true);
    }
}
