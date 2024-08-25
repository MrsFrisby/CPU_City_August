using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAudioSlimeMinion : MonoBehaviour
{

    public AudioSource attackAudioPlayer;

    
    public AudioClip[] attackSounds;




    // Start is called before the first frame update
    void Start()
    {
        attackAudioPlayer = GetComponent<AudioSource>();
    }

    private void PlayAttackAudio()
    {
            int randomIndex = Random.Range(0, attackSounds.Length - 1);
            AudioClip randomClip = attackSounds[randomIndex]; 
            attackAudioPlayer.clip = randomClip;
            attackAudioPlayer.Play();
    }

    
}
