using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesAI : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;


    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {

        player = GameObject.Find("Player").transform;


    }

    private void Update()
    {

        //Setting variables
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //Moving pattern decide
        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    }

    private void Patrolling()
    {

        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
        {

            agent.SetDestination(walkPoint);

        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {

            walkPointSet = false;

        }

    }

    private void SearchWalkPoint()
    {

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //check whether the walkPoint is out of border
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {

            walkPointSet = true;


        }

    }

    private void ChasePlayer()
    {

        agent.SetDestination(player.position);

    }

    private void AttackPlayer()
    {

        //Make sure enemies don't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            //Attack Mode here

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }

    }

    private void ResetAttack()
    {

        alreadyAttacked = false;

    }

}
