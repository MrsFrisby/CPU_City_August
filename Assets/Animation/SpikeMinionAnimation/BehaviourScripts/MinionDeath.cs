using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionDeath : MonoBehaviour
{
    public int Health = 100;
    public Animator animator;
    public AudioSource audioSource;
    public List<AudioClip> minionImpactSFX;

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0 )
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            audioSource.PlayOneShot(minionImpactSFX[1]);
            audioSource.PlayOneShot(minionImpactSFX[0]);
        }
        else
        {
            
            animator.SetTrigger("getHit");
            audioSource.PlayOneShot(minionImpactSFX[1]);
            audioSource.PlayOneShot(minionImpactSFX[2]);
        }
    }
}
