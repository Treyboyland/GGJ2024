using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathAnimation : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    float unitsPerSecond;

    bool shouldGrow = false;

    float elapsed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldGrow)
        {
            player.transform.localScale += player.transform.localScale * Time.deltaTime * unitsPerSecond;
        }
    }

    public void DoDeathAnimation()
    {
        player.PlayerCollider.enabled = false;
        shouldGrow = true;
    }
}
