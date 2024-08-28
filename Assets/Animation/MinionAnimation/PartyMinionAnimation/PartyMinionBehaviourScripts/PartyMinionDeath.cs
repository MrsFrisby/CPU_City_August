using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PartyMinionDeath : MonoBehaviour
{
    public int Health = 100;
    public Animator animator;
    public AudioSource audioSource;
    [SerializeField] private AudioMixerGroup audioMixerGroup; // Reference to the AudioMixerGroup
    public List<AudioClip> minionImpactSFX;

    void Start()
    {
        // Ensure the AudioSource uses the AudioMixerGroup
        if (audioSource != null && audioMixerGroup != null)
        {
            audioSource.outputAudioMixerGroup = audioMixerGroup;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0 )
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            audioSource.PlayOneShot(minionImpactSFX[0]);
            audioSource.PlayOneShot(minionImpactSFX[1]);
            StartCoroutine(Ressurect(10.0f));
        }
        else
        {
            animator.SetTrigger("getHit");
            audioSource.PlayOneShot(minionImpactSFX[0]);
            audioSource.PlayOneShot(minionImpactSFX[Random.Range(2, minionImpactSFX.Count - 1)]);
        }
    }

    IEnumerator Ressurect(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(delay*2);
        animator.SetBool("isIdle", true);
        this.gameObject.SetActive(true);
    }
}
