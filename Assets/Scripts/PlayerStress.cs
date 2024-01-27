using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStress : MonoBehaviour
{
    [SerializeField]
    float startingStress;

    [SerializeField]
    FloatValue stress;

    [SerializeField]
    FloatValue maxStress;

    [SerializeField]
    GameEvent playerDeath;

    bool hasDied;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        stress.Value = startingStress;
    }

    void Update()
    {
        if (StressProgress >= 1 && !hasDied)
        {
            hasDied = true;
            playerDeath.Invoke();
        }
    }

    public float StressProgress
    {
        get => stress.Value / maxStress.Value;
    }
}
