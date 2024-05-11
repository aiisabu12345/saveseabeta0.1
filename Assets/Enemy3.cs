using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
public class Enemy3 : MonoBehaviour
{
    [SerializeField] ParticleSystem beam = null;

    private float cd = 1f, time;

    public Animator _animator;

    LineRenderer laserLine;

    public float laserDuration = 1f;

    public PlayerStatus playerstatus;

    public Transform bs;

    public NavMeshAgent agent;

    public Transform player;

    private Vector3 playerpos;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    private Vector3 _currentVelocity = Vector3.zero;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked = false;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        playerstatus = GameObject.FindObjectOfType<PlayerStatus>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        time = cd;
        laserLine = GetComponent<LineRenderer>();
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
            TakeDamage(Playerupgradevalue.damage);
    }

    private void LateUpdate()
    {
        playerpos = Vector3.SmoothDamp(bs.position, player.position + new Vector3(0,1,0), ref _currentVelocity, 3f);
    }

    private void Update()
    {

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange)
        {
            Debug.DrawRay(bs.position, (playerpos - bs.position)  * 1000, Color.red);
            AttackPlayer();
        }
     }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        ///Attack code here
        RaycastHit hit;
        if (!alreadyAttacked)
        {
            laserLine.SetPosition(0, bs.position);
            if (Physics.Raycast(bs.position, (playerpos - bs.position), out hit, attackRange) && hit.transform.tag == "Player")
            {
                beam.Play();
                _animator.SetTrigger("attack");
                laserLine.SetPosition(1, hit.point);
                laserLine.enabled = true;
                cd -= Time.deltaTime;
                Debug.Log("hit");
                if (cd <= 0)
                {
                    playerstatus.TakeDamage(10f);
                    cd = time;
                }
            }
            Invoke(nameof(stopAttack), laserDuration);
        }
    }

    private void stopAttack()
    {
        beam.Stop();
        _animator.SetTrigger("normal");
        laserLine.enabled = false;
        alreadyAttacked = true;
        Debug.Log("stopATTACK");
        Invoke(nameof(startAttack), timeBetweenAttacks);
    }

    private void startAttack()
    {
        alreadyAttacked = false;
        Debug.Log("startATTACK");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
