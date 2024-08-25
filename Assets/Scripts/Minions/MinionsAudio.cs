using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class MinionsAudio : MonoBehaviour
{
   

    public List<AudioClip> minionPatrolSFX;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayMinionSFX());
    }


    IEnumerator PlayMinionSFX()
    {
        if (!audioSource.isPlaying)
        {
            yield return new WaitForSeconds(Random.Range(1, 20));
            //error here:index was out of range
            AudioClip clip = minionPatrolSFX[Random.Range(0, minionPatrolSFX.Count-1)];
            audioSource.PlayOneShot(clip);
            StartCoroutine(PlayMinionSFX());
        }
        else
        {
            yield return null;
            StartCoroutine(PlayMinionSFX());
        }
    }

    //public void UponDeath()
    //{
    //    StopAllCoroutines();
        
    //}
}