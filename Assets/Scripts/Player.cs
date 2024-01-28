using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    FloatValue speed;

    [SerializeField]
    Animator animator;

    [SerializeField]
    BoolValue isVibing;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    Collider2D playerCollider;

    private Vector2 currentMovementVector;

    public bool CanMove { get; set; } = true;

    public bool IsFast { get; set; } = false;

    public bool HasPaid { get; set; } = false;

    public Collider2D PlayerCollider { get => playerCollider; }

    const string MOVEMENT_VALUE = "MovementValue";
    const string IS_MOVING = "IsMoving";
    const string MORE_VERTICAL = "MoreVertical";

    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        SetAnimationTriggers();
    }

    void SetAnimationTriggers()
    {

        animator.SetBool(IS_MOVING, CanMove && currentMovementVector.sqrMagnitude != 0);
        bool useY = Mathf.Abs(currentMovementVector.y) > Mathf.Abs(currentMovementVector.x);
        animator.SetBool(MORE_VERTICAL, useY);
        animator.SetFloat(MOVEMENT_VALUE, useY ? currentMovementVector.y : currentMovementVector.x);
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
        if (CanMove && !isVibing.Value)
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
