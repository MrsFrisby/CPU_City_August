//https://www.youtube.com/watch?v=OCd7terfNxk&list=PLx7AKmQhxJFaBjiP5uxv7pJ_T2lMIZOBD&index=14
//Ketra Games

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingBlend : StateMachineBehaviour
{
    [SerializeField]
    private float timeUntilChange;

    [SerializeField]
    private int numberOfDanceAnimations;

    private bool isIdle;
    private float waitTime;
    private int danceAnimation;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetBaseIdle();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isIdle == false)
        {
            waitTime += Time.deltaTime;

            if (waitTime > timeUntilChange && stateInfo.normalizedTime % 1 < 0.02f)
            {
                isIdle = true;
                danceAnimation = Random.Range(1, numberOfDanceAnimations + 1);
                danceAnimation = danceAnimation * 2 - 1;

                animator.SetFloat("DanceBlend", danceAnimation - 1);
                Debug.Log("Dance Animation Change");
                Debug.Log("DanceBlend:" + animator.GetFloat("DanceBlend"));

            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetBaseIdle();
        }


        animator.SetFloat("DanceBlend", danceAnimation, 0.2f, Time.deltaTime);
    }

    private void ResetBaseIdle()
    {

        if (isIdle)
        {
            danceAnimation--;
        }

        isIdle = false;
        waitTime = 0;
        
        Debug.Log("Base Idle Reset");
    }
}

