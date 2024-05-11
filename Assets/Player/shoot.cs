using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Transform bulletspawnpoint1;
    public Transform bulletspawnpoint2;
    public Transform bulletspawnpoint3;
    public GameObject bulletprefab;
    public float bulletspeed = 2;
    public float cd, time;

    void start()
    {
        cd = 2f;
        time = 2f;
    }

    void Update()
    {
        cd -= Time.deltaTime;
        if(cd <= 0)
        {
            shooting();
            cd = time;
        }    
    }
    public void shooting()
    {
        var bullet1 = Instantiate(bulletprefab, bulletspawnpoint1.position, bulletspawnpoint1.rotation);
        bullet1.GetComponent<Rigidbody>().velocity = bulletspawnpoint1.forward * bulletspeed;

        var bullet2 = Instantiate(bulletprefab, bulletspawnpoint2.position, bulletspawnpoint2.rotation);
        bullet2.GetComponent<Rigidbody>().velocity = bulletspawnpoint2.forward * bulletspeed;

        var bullet3 = Instantiate(bulletprefab, bulletspawnpoint3.position, bulletspawnpoint3.rotation);
        bullet3.GetComponent<Rigidbody>().velocity = bulletspawnpoint3.forward * bulletspeed;
    }
}
