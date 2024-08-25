//https://www.youtube.com/watch?v=whkC8f3oNOk&list=PL0WgRP7BtOewNtJdJNE-YjlpcU-wl1lAi&index=4
//GDTitans Enemy AI in Unity 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMinionIdleState : StateMachineBehaviour
{

    float timer = 0;
    Transform player;
    float chaseRange = 8;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            animator.SetBool("isPatrolling", true);
            animator.SetBool("isIdle", false);
            //Debug.Log("Patrolling");

            float distance = Vector3.Distance(player.position, animator.transform.position);
            if(distance < chaseRange)
            {
                animator.SetBool("isChasing", true);
                animator.SetBool("isIdle", false);
            }

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

  
}
