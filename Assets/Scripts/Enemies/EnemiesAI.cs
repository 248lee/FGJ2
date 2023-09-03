using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class EnemiesAI : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, chaseRange, attackRange;
    public bool playerInSightRange, playerInChaseRange, playerInAttackRange;

    // for fire
    public GameObject bulletPrefab;
    public GameObject bulletPoint;
    public float bulletSpeed = 5f;
    public float destroyTime = 1f;


    private void Awake()
    {

        player = GameObject.Find("Tank").transform;

    }

    private void Update()
    {

        //Setting variables
        playerInSightRange = Vector3.Distance(transform.position, player.position) > sightRange;
        playerInChaseRange = Vector3.Distance(transform.position, player.position) < sightRange && Vector3.Distance(transform.position, player.position) > chaseRange;
        playerInAttackRange = Vector3.Distance(transform.position, player.position) < chaseRange;

        //Debug.Log("Sight = " + playerInSightRange);
        //Moving pattern decide
        if (playerInSightRange) Patrolling();
        if (playerInChaseRange) ChasePlayer();
        if (playerInAttackRange) AttackPlayer();

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
        //agent.SetDestination(transform.position);
        agent.ResetPath();
        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            //Attack Mode here
            Fire();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }

    }

    private void ResetAttack()
    {

        alreadyAttacked = false;

    }

    private void Fire()
    {
        GameObject bullet;
        if (bulletPoint != null)
        {
            bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);
            //bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
            bullet.GetComponent<Rigidbody>().velocity = (player.transform.position - bulletPoint.transform.position) * bulletSpeed;
            Destroy(bullet, destroyTime);
        }
    }

    public void IsDamaged()
    {

        Destroy(gameObject);

    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(transform.position, attackRange);

    }
}
