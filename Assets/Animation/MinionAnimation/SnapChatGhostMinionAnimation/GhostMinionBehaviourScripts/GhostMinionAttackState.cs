//https://www.youtube.com/watch?v=b-WZEBLNCik&list=PL0WgRP7BtOewNtJdJNE-YjlpcU-wl1lAi&index=5
//script modified from GDTitans YouTube tutorial 3D Enemy AI in Unity Chase and Attack
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GhostMinionAttackState : StateMachineBehaviour
{
    Transform player;
    //private List<AudioClip> minionAttackAudio = this.GameObject.GetComponent<PartyMinionDeath>().minionImpactSFX;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetInteger("AttackIndex", Random.Range(0, 3));
        animator.SetTrigger("attack");
        AudioSource audioSource = animator.GetComponent<AudioSource>();
        audioSource.enabled = true;
        audioSource.Play();


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 3f)
        {
            animator.SetBool("isAttacking", false);
        }
            
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            {
                animator.SetInteger("AttackIndex", Random.Range(0, 3));
                animator.SetTrigger("attack");
            }
                
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
