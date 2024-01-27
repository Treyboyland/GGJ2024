using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantStressOnTrigger : MonoBehaviour
{
    [SerializeField]
    ConstantStress stressor;

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
            stressor.IsStressActive = true;
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
        }
    }
}
