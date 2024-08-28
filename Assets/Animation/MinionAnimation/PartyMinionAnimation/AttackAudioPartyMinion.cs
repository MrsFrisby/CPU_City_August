using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AttackAudioPartyMinion : MonoBehaviour
{
    public AudioSource attackAudioPlayer;
    [SerializeField] private AudioMixerGroup audioMixerGroup; // Reference to the AudioMixerGroup
    public AudioClip[] attackSounds;

    // Start is called before the first frame update
    void Start()
    {
        attackAudioPlayer = GetComponent<AudioSource>();
        
        // Set the AudioSource's output to the specified AudioMixerGroup
        if (attackAudioPlayer != null && audioMixerGroup != null)
        {
            attackAudioPlayer.outputAudioMixerGroup = audioMixerGroup;
        }
    }

    private void PlayAttackAudio()
    {
        int randomIndex = Random.Range(0, attackSounds.Length - 1);
        AudioClip randomClip = attackSounds[randomIndex]; 
        attackAudioPlayer.clip = randomClip;
        attackAudioPlayer.Play();
    }
}
