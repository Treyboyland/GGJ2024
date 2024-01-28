using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    RemainingUI allCollected;

    [SerializeField]
    GameEvent gameWon;

    [SerializeField]
    GameEvent gameWonStoleStuff;

    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
