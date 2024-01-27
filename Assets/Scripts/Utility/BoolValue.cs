using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bool-", menuName = "Utility/Bool", order = 1)]
public class BoolValue : ScriptableObject
{
    [SerializeField]
    bool value;

    public bool Value { get => value; set => this.value = value; }
}
