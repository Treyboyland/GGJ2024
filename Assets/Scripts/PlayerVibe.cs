using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVibe : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    BoolValue isVibing;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    ConstantStressOnTrigger overworldStress;

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
        float active = context.ReadValue<float>();

        //Debug.Log("Vibing: " + active);

        isVibing.Value = active > 0;

        if (isVibing.Value)
        {
            source.Play();
            overworldStress.ShouldRun = false;
            destresser.IsStressActive = true;
            vibeIncreaser.IsStressActive = true;
        }
        else
        {
            source.Stop();
            overworldStress.ShouldRun = true;
            destresser.IsStressActive = false;
            vibeIncreaser.IsStressActive = false;
        }
    }
}
