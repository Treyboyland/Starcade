using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotationalSpeed : MonoBehaviour
{
    [SerializeField]
    Vector2 speedRange = new Vector2();

    [SerializeField]
    bool useSetRange = false;

    [SerializeField]
    float setSpeed = 0;

    private void OnEnable()
    {
        if (!useSetRange)
        {
            setSpeed = Random.Range(speedRange.x, speedRange.y) * (Random.Range(0.0f, 1.0f) < 0.5f ? 1 : -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = new Vector3();
        delta.z = Time.deltaTime * setSpeed;
        transform.Rotate(delta, Space.Self);
    }
}
