using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hedgehog : MonoBehaviour
{
    #region Fields
    [Header("References")]
    // Reference to navmesh agent
    public NavMeshAgent agent;

    // Reference to player follow point
    public Transform playerFollowPoint;

    // Move speeds
    public float followingSpeed;
    public float smashingSpeed;

    // Distance between hedgehog and player
    public float distanceToPlayer;

    // State enum
    public enum States
    {
        Following,
        Smashing
    }
    public States state;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Get navmeshagent 
        agent = gameObject.GetComponent<NavMeshAgent>();

        // Set initial state to following
        state = States.Following;

        // Get initial follow point
        agent.SetDestination(playerFollowPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Update follow position only if following
        switch (state)
        {
            case States.Following:
                {
                    agent.SetDestination(playerFollowPoint.position);
                    agent.speed = followingSpeed;

                    // If hedgehog is getting too close to player
                    if (Vector3.Distance(transform.position, agent.destination) <= distanceToPlayer)
                    {
                        agent.isStopped = true;
                    }
                    else
                    {
                        agent.isStopped = false;
                    }
                }
                break;

            case States.Smashing:
                {
                    agent.isStopped = false;
                    agent.speed = smashingSpeed;
                }
                break;
        }

    }

    /// <summary>
    /// Be given a target to run and smah into
    /// </summary>
    /// <param name="target">The game object to smash into</param>
    public void SmashObstacle(GameObject target)
    {
        // Set state to smashing
        state = States.Smashing;

        // Set new agent destination to target
        agent.SetDestination(target.transform.position);
    }

    public void SmashSuccessful()
    {
        // Play random celebration sound later on 

        // Reset state
        state = States.Following;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SmashableWall"))
        {
            collision.gameObject.SendMessage("GetSmashed", this);
        }
    }
}
