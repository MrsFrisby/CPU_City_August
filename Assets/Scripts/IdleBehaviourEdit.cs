//https://www.youtube.com/watch?v=OCd7terfNxk&list=PLx7AKmQhxJFaBjiP5uxv7pJ_T2lMIZOBD&index=14
//Ketra Games

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviourEdit : StateMachineBehaviour
{
    [SerializeField]
    private float timeUntilChange;

    [SerializeField]
    private int numberOfIdleAnimations;

    private bool isExtraIdle;
    private float waitTime;
    private int idleAnimation;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetBaseIdle();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isExtraIdle == false)
        {
            waitTime += Time.deltaTime;

            if (waitTime > timeUntilChange && stateInfo.normalizedTime % 1 < 0.02f)
            {
                isExtraIdle = true;
                idleAnimation = Random.Range(1, numberOfIdleAnimations + 1);
                //idleAnimation = idleAnimation * 2 - 1;

                //animator.SetFloat("IdleBlend", idleAnimation - 1);
                Debug.Log("Idle Animation Change");
                Debug.Log("IdleBlend:" + animator.GetFloat("IdleBlend"));

            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetBaseIdle();
        }


        animator.SetFloat("IdleBlend", idleAnimation, 0.15f, Time.deltaTime);
    }

    private void ResetBaseIdle()
    {

        //if (isExtraIdle)
        //{
        //    idleAnimation--;
        //}

        isExtraIdle = false;
        waitTime = 0;
        idleAnimation = 0;
        Debug.Log("Base Idle Reset");
    }
}

