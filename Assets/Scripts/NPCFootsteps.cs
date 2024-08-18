using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCFootsteps : MonoBehaviour
{

    public AudioSource NPCfootstepPlayer;

    
    public AudioClip[] tileStepsWalk;
    




    // Start is called before the first frame update
    void Start()
    {
        NPCfootstepPlayer = GetComponent<AudioSource>();
    }

    private void PlayFootsteps()   
    {
        int randomIndex = Random.Range(0, tileStepsWalk.Length);
        AudioClip randomClip = tileStepsWalk[randomIndex];

        NPCfootstepPlayer.clip = randomClip;
        NPCfootstepPlayer.Play();
    }

    
}
