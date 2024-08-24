using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseState
{
    #region Variables
    protected List<Transform> targets;
    protected int targetIndex;

    protected float waitTime;
    protected float checkTime;
    protected float distanceToTarget;

    protected NavMeshAgent agent;

    protected GameObject player;
    protected GameObject NPC;

    protected float chaseTriggerDistance;
    protected float chaseQuitDistance;

    protected NpcFSM FSM;

    protected float chaseSpeed;
    protected float patrolSpeed;

    #endregion

    //setting variables for all derivitive states


    public virtual void EnterState(NpcFSM npc)
    {
        targets = npc.targets;

        waitTime = npc.waitTime;
        checkTime = npc.checkTime;
        distanceToTarget = npc.distanceToTarget;

        agent = npc.agent;


        NPC = npc.NPCgO;
        player = npc.player;

        chaseTriggerDistance = npc.chaseTriggerDistance;
        chaseQuitDistance = npc.chaseQuitDistance;

        FSM = npc;

        chaseSpeed = npc.NPCChaseSpeed;
        patrolSpeed = npc.NPCPatrolSpeed;

    }
}
