// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class PatrolWithWait : MonoBehaviour
{
    public Animator animator;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool isIdle;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = true;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    IEnumerator Wait()
    {
        animator.SetBool("Idle", isIdle);
        yield return new WaitForSeconds(10.0f);
        isIdle = false;
        animator.SetBool("Idle", isIdle);

        GotoNextPoint();
    }

    void Update()
    {
        if (agent.isOnOffMeshLink)
        {
            agent.speed = 1f;

            if (animator != null)
            {
                if (!animator.GetBool("Climbing"))
                {
                    animator.SetBool("Climbing", true);
                }
            }

        }
        else
        {
            agent.speed = 2f;

            if (animator != null)
            {
                if (animator.GetBool("Climbing"))
                {
                    animator.SetBool("Climbing", false);
                }
            }
        }

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f && isIdle == false)
        {
            isIdle = true;
            StartCoroutine(Wait());
        }
    }
}