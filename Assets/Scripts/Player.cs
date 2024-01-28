using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    FloatValue speed;

    FloatValue fastSpeed;



    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    Collider2D playerCollider;

    private Vector2 currentMovementVector;

    public bool CanMove { get; set; } = true;

    public bool IsFast { get; set; } = false;

    public Collider2D PlayerCollider { get => playerCollider; }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void HandleMove(InputAction.CallbackContext context)
    {
        //Debug.LogWarning("Movement vector: " + currentMovementVector);
        currentMovementVector = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        if (CanMove)
        {
            Move();
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }

    void Move()
    {
        Vector2 movement = currentMovementVector;
        // if (movement != new Vector2())
        // {
        //     elapsed = 0;
        // }
        movement *= speed.Value * Time.fixedDeltaTime;
        //body.AddForce(movement, ForceMode2D.Impulse);
        body.MovePosition((Vector2)body.transform.position + movement);
    }
}
