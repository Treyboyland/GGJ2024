using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    [SerializeField]
    RemainingUI hasAllCheck;

    [SerializeField]
    BoolValue hasStolen;

    [SerializeField]
    AudioSource alarm;

    [SerializeField]
    TMP_Text text;

    [SerializeField]
    AudioSource thankYouSource;

    bool hasPaid = false;

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
        var player = other.gameObject.GetComponent<Player>();

        if (player && !hasPaid)
        {
            RunCheck(player);
        }
    }


    void RunCheck(Player player)
    {
        if (hasAllCheck.HasAll())
        {
            player.HasPaid = true;
            alarm.Stop();
            hasPaid = true;
            text.text = "Thank you!";
            hasStolen.Value = false;
        }
    }
}
