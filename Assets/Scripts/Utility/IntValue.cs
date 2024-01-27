using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Int-", menuName = "Utility/Int", order = 1)]
public class IntValue : ScriptableObject
{
    [SerializeField]
    float value;

    public float Value => value;
}
