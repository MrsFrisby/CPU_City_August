using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NPCFootsteps : MonoBehaviour
{
    public AudioSource NPCfootstepPlayer;
    [SerializeField] private AudioMixerGroup audioMixerGroup; // Reference to the AudioMixerGroup
    public AudioClip[] tileStepsWalk;
    
    // Start is called before the first frame update
    void Start()
    {
        NPCfootstepPlayer = GetComponent<AudioSource>();

        // Set the AudioSource's output to the specified AudioMixerGroup
        if (NPCfootstepPlayer != null && audioMixerGroup != null)
        {
            NPCfootstepPlayer.outputAudioMixerGroup = audioMixerGroup;
        }
    }

    private void PlayFootsteps()   
    {
        int randomIndex = Random.Range(0, tileStepsWalk.Length);
        AudioClip randomClip = tileStepsWalk[randomIndex];

        NPCfootstepPlayer.clip = randomClip;
        NPCfootstepPlayer.Play();
    }
}
