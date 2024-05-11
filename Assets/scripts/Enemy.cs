using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    private Rigidbody rb;
    private Vector3 movement;
    public float atkrange = 0.5f;
    public LayerMask playerlayer;
    public PlayerStatus playerstatus;
    bool Inatkrange;
    float cd, time;

    void Start()
    {
        cd = 0.5f;
        time = 0.5f;
        playerstatus = GameObject.FindObjectOfType<PlayerStatus>();
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>(); // Initialize the Rigidbody
        movement = Vector3.zero; // Initialize movement
    }

    void Update()
    {
        Inatkrange = Physics.CheckSphere(transform.position, atkrange, playerlayer);

        if (Inatkrange)
        {
            cd -= Time.deltaTime;
            if (cd <= 0)
            {
                Attack();
                cd = time;
            }
        }
    }

    private void FixedUpdate()
    {
        if (player != null) // Check if player exists
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            rb.rotation = Quaternion.Euler(0, angle, 0); // Set rotation using Quaternion.Euler
            direction.Normalize();
            movement = direction;
            moveCharacter(movement);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Bullet")
            Destroy(gameObject);
    }

    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }
    void Attack()
    {
        playerstatus.TakeDamage(5f);
    }
}