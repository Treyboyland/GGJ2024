using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheftCheck : MonoBehaviour
{
    [SerializeField]
    RemainingUI remainingUI;

    [SerializeField]
    AudioSource alarm;

    [SerializeField]
    FloatValue stressForTheft;

    [SerializeField]
    FloatValue playerStress;

    [SerializeField]
    BoolValue hasStolen;

    bool firedOnce = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

        if (player)
        {
            RunCheck(player);
        }
    }

    void AddStress()
    {
        playerStress.Value += stressForTheft.Value;
    }

    void RunCheck(Player player)
    {
        if (!player.HasPaid && remainingUI.HasAny())
        {
            hasStolen.Value = true;
            if(!alarm.isPlaying)
            {
                alarm.Play();
            }
            if (!firedOnce)
            {
                firedOnce = true;
                AddStress();
            }
        }
    }
}
