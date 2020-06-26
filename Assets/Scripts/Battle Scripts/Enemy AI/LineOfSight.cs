using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField]
    float distance = 0.0f;

    [SerializeField]
    string[] detectionLayers = new string[] { "Default" };

    public BoolEvent OnObjectSighted = new BoolEvent();


    // Update is called once per frame
    void Update()
    {
        var pos = new Vector2(transform.position.x, transform.position.y);
        var ray = new Vector2(transform.up.x, transform.up.y);

        //Debug.LogWarning(gameObject.name + ": " + pos + " ray " + ray + " dist: " + distance + " id: " + LayerMask.NameToLayer(detectionLayer));
        var raycast = Physics2D.Raycast(pos, ray, distance, LayerMask.GetMask(detectionLayers));

        OnObjectSighted.Invoke(raycast.collider != null);
    }
}
