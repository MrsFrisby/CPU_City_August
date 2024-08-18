using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MinionHit : MonoBehaviour
{
    //not the best way to do audio but it works
    //events and a SFX manager might be better.
    [SerializeField]
    private AudioClip clip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Minions minion = other.GetComponent<Minions>();

        if (minion != null && minion.enabled)
        {
            minion.Die();
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(clip);
        }
    }
}