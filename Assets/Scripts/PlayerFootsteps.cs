using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerFootsteps : MonoBehaviour
{

    public AudioSource footstepPlayer;

    //public AudioClip[] tileSteps;
    //public AudioClip[] metalSteps;
    public AudioClip[] streetStepsWalk;
    public AudioClip[] streetStepsRun;




    // Start is called before the first frame update
    void Start()
    {
        footstepPlayer = GetComponent<AudioSource>();
    }

    private void PlayFootsteps()   
    {
        if (Input.anyKey)
        //Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
        {
            int randomIndex = Random.Range(0, streetStepsWalk.Length-1);
            AudioClip randomClip = streetStepsWalk[randomIndex];

            footstepPlayer.clip = randomClip;
            footstepPlayer.Play();
            //Debug.Log(randomClip.name);
        }
        
    }

    private void PlayRunningFootsteps()
    {
        int randomRunIndex = Random.Range(0, streetStepsRun.Length-1);
        AudioClip randomRunClip = streetStepsRun[randomRunIndex];

        footstepPlayer.clip = randomRunClip;
        footstepPlayer.Play();
    }
}
