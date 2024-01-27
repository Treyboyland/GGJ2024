using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float-", menuName = "Utility/Float", order = 1)]
public class FloatValue : ScriptableObject
{
    [SerializeField]
    float value;

    public float Value { get => value; set => this.value = value; }
}
