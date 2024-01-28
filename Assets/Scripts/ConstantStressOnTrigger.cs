using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantStressOnTrigger : MonoBehaviour
{
    [SerializeField]
    ConstantStress stressor;

    [SerializeField]
    GameEvent onTriggerEntered;

    [SerializeField]
    GameEvent onTriggerExited;

    bool shouldRun = true;

    public bool ShouldRun
    {
        set
        {
            shouldRun = value;
            if (!shouldRun)
            {
                stressor.IsStressActive = false;
            }
            else if (inside)
            {
                stressor.IsStressActive = true;
            }
        }
    }

    bool inside = false;

    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (!shouldRun)
    //     {
    //         return;
    //     }

    //     var player = other.gameObject.GetComponent<Player>();
    //     if (player)
    //     {
    //         stressor.IsStressActive = true;
    //     }
    // }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            inside = true;
            onTriggerEntered.Invoke();
            if (shouldRun)
            {
                stressor.IsStressActive = true;
            }
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            stressor.IsStressActive = false;
            inside = false;
            onTriggerExited.Invoke();
        }
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        stressor.IsStressActive = false;
    }
}
