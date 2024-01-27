using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAcquiredUI : MonoBehaviour
{
    [SerializeField]
    GameObject notAcquiredObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAcquired(bool isAcquired)
    {
        notAcquiredObject.SetActive(!isAcquired);
    }
}
