using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "enemybullet" && collision.gameObject.tag != "canPickUp" && collision.gameObject.tag != "water" && collision.gameObject.tag != "enemy")
        {
            Destroy(gameObject);
        }

    }
}
