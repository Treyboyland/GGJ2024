using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitialBoolValue : MonoBehaviour
{
    [SerializeField]
    bool initial;

    [SerializeField]
    BoolValue boolValue;

    // Start is called before the first frame update
    void Awake()
    {
        boolValue.Value = initial;
    }
}
