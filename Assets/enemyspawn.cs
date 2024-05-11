using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawn : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    public float cd = 20f, time;

    public BossStatus bossstatus;

    void Awake()
    {
        time = cd;
        bossstatus = GameObject.FindObjectOfType<BossStatus>();
    }

    void Update()
    {
        cd -= Time.deltaTime;
        if(bossstatus.currentHealth > (bossstatus.maxHealth / 100) * 50 && cd <= 0)
        {
            Instantiate(enemy1, transform.position, Quaternion.identity);
            cd = time;
        }
        else if(cd <= 0 && bossstatus.currentHealth > (bossstatus.maxHealth / 100) * 25)
        {
            Instantiate(enemy2, transform.position, Quaternion.identity);
            cd = time;
        }
    }
}
