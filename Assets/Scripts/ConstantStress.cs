using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantStress : MonoBehaviour
{
    [SerializeField]
    FloatValue playerStress;

    [SerializeField]
    FloatValue stressPerSecond;

    public bool IsStressActive;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsStressActive)
        {
            playerStress.Value += stressPerSecond.Value * Time.deltaTime;
        }
    }
}
