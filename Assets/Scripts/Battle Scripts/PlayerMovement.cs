using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D body = null;

    [SerializeField]
    Ship playerShip = null;

    [SerializeField]
    Vector2 minPosition = new Vector2();

    [SerializeField]
    Vector2 maxPosition = new Vector2();

    private void FixedUpdate()
    {
        Vector2 movement;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        Vector2 newPos = transform.position;
        newPos += movement * playerShip.CurrentSpeed * Time.fixedDeltaTime;

        newPos = Vector2.Min(newPos, maxPosition);
        newPos = Vector2.Max(newPos, minPosition);

        body.MovePosition(newPos);
    }
}
