//script adapted from https://www.youtube.com/watch?v=whkC8f3oNOk&list=PL0WgRP7BtOewNtJdJNE-YjlpcU-wl1lAi&index=4
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PartyMinionPatrolState : StateMachineBehaviour
{
    float timer;
    List<Transform> partyTargets = new List<Transform> ();
    NavMeshAgent agent;
    Transform player;
    float chaseRange = 5;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
        timer = 0;
        GameObject gO = GameObject.FindGameObjectWithTag("PartyTargets");
        foreach (Transform t in gO.transform)
            partyTargets.Add(t);

        agent.SetDestination(partyTargets[Random.Range(0, partyTargets.Count)].position);
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(partyTargets[Random.Range(0, partyTargets.Count)].position);
        }

        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatrolling", false);
            //Debug.Log("Not Patrolling");
        }

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

  
}
