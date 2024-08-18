using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class PatrolState : BaseState
{

    public override void EnterState(NpcFSM npc)
    {
        base.EnterState(npc);



        agent.speed = patrolSpeed;

        setDestination();
    }


    void setDestination()
    {
        agent.destination = targets[targetIndex].position;

        FSM.StartCoroutine(patrolStatusCheck());
    }

    IEnumerator patrolStatusCheck()
    {
        yield return new WaitForSeconds(checkTime);

        if (agent.remainingDistance < distanceToTarget)
        {
            FSM.StartCoroutine(WaitThenChoose());
        }
        else if (Vector3.Distance(player.transform.position, FSM.NPCgO.transform.position) < chaseTriggerDistance)
        {
            FSM.MoveToState(FSM.s_Chase);
        }
        else
        {
            FSM.StartCoroutine(patrolStatusCheck());
        }

    }
    IEnumerator WaitThenChoose()
    {
        yield return new WaitForSeconds(waitTime);
        NextDestination();
    }

    void NextDestination()
    {
        targetIndex += 1;
        if (targetIndex > targets.Count - 1)
        {
            targetIndex = 0;
        }

        setDestination();
    }
}