using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicInterruption : MonoBehaviour
{
    [SerializeField]
    BoolValue playSounds;

    [SerializeField]
    float creepyPercentage;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioSource backgroundSource;

    [SerializeField]
    AudioClip startingClip;

    [SerializeField]
    FloatValue secondsBetweenAnnouncements;

    [SerializeField]
    FloatValue playerCurrentstress;

    [SerializeField]
    FloatValue stressToAdd;

    [SerializeField] private List<AudioClip> interruptions;
    [SerializeField] private List<AudioClip> creepyInterruptions;

    bool isAnnouncing = false;

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playSounds.Value && !isAnnouncing)
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
        backgroundSource.mute = true;
        source.mute = !playSounds.Value;
        source.clip = startingClip;
        source.Play();
        bool useCreepy = Random.Range(0.0f, 1.0f) < creepyPercentage;
        while (source.isPlaying)
        {
            source.mute = !playSounds.Value;
            yield return null;
        }

        source.clip = useCreepy ? creepyInterruptions.SelectRandom() : interruptions.SelectRandom();
        source.Play();

        while (source.isPlaying)
        {
            source.mute = !playSounds.Value;
            yield return null;
        }

        //Debug.LogWarning("Done announcing");
        source.mute = !playSounds.Value;
        backgroundSource.mute = !playSounds.Value;
        isAnnouncing = false;
    }
}
