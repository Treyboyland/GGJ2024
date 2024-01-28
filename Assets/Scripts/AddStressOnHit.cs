using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStressOnHit : MonoBehaviour
{
    [SerializeField]
    FloatValue playerCurrentstress;

    [SerializeField]
    FloatValue stressToAdd;

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player)
        {
            playerCurrentstress.Value += stressToAdd.Value;
        }
    }
}