using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
    }
}
