using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{
    public GameObject target;
    public Animator animator;
    private NavMeshAgent agent;
    private bool isIdle;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.isOnOffMeshLink)
        {
            agent.speed = 1f;
        }
        else
        {
            agent.speed = 3.5f;
        }

        agent.destination = target.transform.position;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }
    }
}
