using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class ChaseState : BaseState
{
    public override void EnterState(NpcFSM npc)
    {
        base.EnterState(npc);

        agent.speed = chaseSpeed;

        FSM.StartCoroutine(chaseStatusCheck());
    }

    IEnumerator chaseStatusCheck()
    {
        yield return new WaitForSeconds(checkTime);

        if (Vector3.Distance(player.transform.position, FSM.NPCgO.transform.position) < chaseQuitDistance)
        {
            agent.destination = player.transform.position;
            FSM.StartCoroutine(chaseStatusCheck());
        }
        else
        {
            FSM.MoveToState(FSM.s_Patrol);
        }
    }
}