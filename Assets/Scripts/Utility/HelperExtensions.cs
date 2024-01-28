using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperExtensions
{
    public static T SelectRandom<T>(this List<T> items)
    {
        int index = Random.Range(0, items.Count);
        return items[index];
    }
}
