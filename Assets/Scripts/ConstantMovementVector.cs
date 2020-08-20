using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ConstantMovementVector : MonoBehaviour
{
    [SerializeField]
    Vector2 movementVector = new Vector2();

    [SerializeField]
    bool flipX = false;

    public bool FlipX
    {
        get
        {
            return flipX;
        }
        set
        {
            flipX = value;
        }
    }

    [SerializeField]
    bool flipY = false;

    public bool FlipY
    {
        get
        {
            return flipY;
        }
        set
        {
            flipY = value;
        }
    }

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            rb2d = rb2d == null ? GetComponentInParent<Rigidbody2D>() : rb2d;
            var velocity = Vector3.RotateTowards(movementVector, transform.up, 2 * Mathf.PI, 0);
            velocity.y *= (transform.up == -Vector3.up ? -1 : 1);
            //Debug.LogWarning(transform.up);
            rb2d.velocity = velocity;
        }
    }

    private void FixedUpdate()
    {

    }
}
