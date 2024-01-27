using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressMeterUI : MonoBehaviour
{
    [SerializeField]
    PlayerStress playerStress;

    [SerializeField]
    Image image;

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = playerStress.StressProgress;
    }
}
