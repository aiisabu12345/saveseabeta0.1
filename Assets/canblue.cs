using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class canblue : MonoBehaviour
{

    [SerializeField] ParticleSystem explosion = null;

    public PlayerStatus playerstatus;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Animator _animator;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    bool alreadyAttacked = false;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        playerstatus = GameObject.FindObjectOfType<PlayerStatus>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            agent.SetDestination(transform.position);
            transform.LookAt(player);
            _animator.SetTrigger("explosion");
            Invoke(nameof(DestroyEnemy), 1f);
        }
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        //Make sure enemy doesn't move

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            _animator.SetTrigger("explosion");
            Invoke(nameof(DestroyEnemy), 1f);
        }

    }

    private void DestroyEnemy()
    {
        explosion.Play();
        if (playerInAttackRange)
        {
            Invoke(nameof(damage), 0.1f);
        }
        Destroy(gameObject, 0.17f);
    }

    private void damage()
    {
        playerstatus.TakeDamage(25f);
    }
}
