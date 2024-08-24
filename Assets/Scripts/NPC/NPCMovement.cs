using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{

    #region Variables
    [Header("Moving Variables")]

    [SerializeField] float waitTime;
    [SerializeField] float checkTime;
    [SerializeField] float distanceToTarget;

    [Header("Target List")]
    [SerializeField] List<Transform> targets;
    [SerializeField] int targetIndex;


    NavMeshAgent agent;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        setDestination();


    }

    void setDestination()
    {
        agent.destination = targets[targetIndex].position;

        StartCoroutine("DestinationCheck");
    }

    IEnumerator DestinationCheck()
    {
        yield return new WaitForSeconds(checkTime);

        if (agent.remainingDistance < distanceToTarget)
        {
            StartCoroutine("WaitThenChoose");
        }
        else
        {
            StartCoroutine("DestinationCheck");
        }

    }
    IEnumerator WaitThenChoose()
    {
        yield return new WaitForSeconds(waitTime);
        SetNextDestination();
    }

    void SetNextDestination()
    {
        targetIndex += 1;
        if (targetIndex > targets.Count - 1)
        {
            targetIndex = 0;
        }

        setDestination();
    }

}
