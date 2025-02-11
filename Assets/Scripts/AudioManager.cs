using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource speaker;

    [SerializeField] AudioClip ambiance;
    [SerializeField] AudioClip dash;
    [SerializeField] AudioClip gem;
    [SerializeField] AudioClip rune;
    [SerializeField] AudioClip unlock;
    [SerializeField] AudioClip door;

    private void Awake()
    {
        instance = this;
        speaker = GetComponent<AudioSource>();

        // If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public static void PlaySound(string actionName)
    {
        switch (actionName)
        {
            case "dash":
                instance.speaker.PlayOneShot(instance.dash, 1);
                break;
            case "gem":
                instance.speaker.PlayOneShot(instance.gem, 1);
                break;
            case "rune":
                instance.speaker.PlayOneShot(instance.rune, 1);
                break;
            case "unlock":
                instance.speaker.PlayOneShot(instance.unlock, 1);
                break;
            case "door":
                instance.speaker.PlayOneShot(instance.door, 1);
                break;
        }
    }
}
