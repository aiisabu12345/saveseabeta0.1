using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfire : MonoBehaviour
{
    public Transform[] bs;
    public GameObject bullet;
    public float cd = 1f;
    public float rotate = 0f;


    public float bulletspeed = 10f;

    private bool alreadyfire = false;

    public BossStatus bossstatus;

    private bool stop = false;
    private bool lastphase = false;

    void Awake()
    {
        bossstatus = GameObject.FindObjectOfType<BossStatus>();
    }

    void Update()
    {
        if (bossstatus.currentHealth > (bossstatus.maxHealth / 100)*50 && bossstatus.currentHealth <= (bossstatus.maxHealth / 100) * 75)
        {
            rotate = 10f;
        }
        else if(bossstatus.currentHealth > (bossstatus.maxHealth / 100) * 25 && bossstatus.currentHealth <= (bossstatus.maxHealth / 100) * 50)
        {
            rotate = 20f;
        }
        else if(bossstatus.currentHealth <= (bossstatus.maxHealth / 100) * 25 && !lastphase)
        {
            rotate = 10f;
            cd = 0.1f;
            lastphase = true;
            Invoke("stopshoot", 2f);
        }

        transform.Rotate(0, rotate * Time.deltaTime, 0);

        if (!alreadyfire && !stop)
        {
            foreach(Transform p in bs)
            {
                fire(p);
            }
            alreadyfire = true;
            Invoke("resetfire", cd);
        }
    }

    public void resetfire()
    {
        alreadyfire = false;
    }

    float t1=0.1f, t2=0.1f;
    public void fire(Transform bs)
    {
        var bullet1 = Instantiate(bullet, bs.position, bs.rotation);
        bullet1.GetComponent<Rigidbody>().velocity = bs.forward * bulletspeed;
    }

    public void stopshoot()
    {
        stop = true;
        Invoke("startshoot", 3f);
    }

    public void startshoot()
    {
        stop = false;
        Invoke("stopshoot", 1f);
    }
}
