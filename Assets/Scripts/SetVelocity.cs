using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVelocity : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D body = null;

    [SerializeField]
    Vector2 setVelocity = new Vector2();

    [SerializeField]
    bool active = false;

    public bool Active { get { return active; } set { active = value; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            body.velocity = setVelocity;
        }
    }
}
