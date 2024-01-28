using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBasedOnValue : MonoBehaviour
{
    [SerializeField]
    GameObject objectToEnable;

    [SerializeField]
    BoolValue value;

    [SerializeField]
    bool invert;

    // Start is called before the first frame update
    void Start()
    {
        objectToEnable.SetActive(invert ? !value.Value : value.Value);
    }
}
