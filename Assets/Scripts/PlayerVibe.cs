using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVibe : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    ConstantStress destresser;

    [SerializeField]
    ConstantStress vibeIncreaser;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleVibe(InputAction.CallbackContext context)
    {

    }
}
