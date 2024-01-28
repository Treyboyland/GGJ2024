using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicInterruption : MonoBehaviour
{
    [SerializeField]
    BoolValue playSounds;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip startingClip;

    [SerializeField]
    FloatValue secondsBetweenAnnouncements;

    [SerializeField]
    FloatValue playerCurrentstress;

    [SerializeField]
    FloatValue stressToAdd;

    [SerializeField] private List<AudioClip> interruptions;

    bool isAnnouncing = false;

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playSounds && !isAnnouncing)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= secondsBetweenAnnouncements.Value)
            {
                elapsed = 0;
                isAnnouncing = true;
                StartCoroutine(PlayAnnouncement());
            }
        }
    }

    IEnumerator PlayAnnouncement()
    {
        playerCurrentstress.Value += stressToAdd.Value;
        source.clip = startingClip;
        source.Play();
        while (source.isPlaying)
        {
            yield return null;
        }

        source.clip = interruptions.SelectRandom();
        source.Play();

        while (source.isPlaying)
        {
            yield return null;
        }

        isAnnouncing = false;
    }
}
