using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserdamage : MonoBehaviour
{
    public PlayerStatus playerstatus;
    private bool trigger = false;

    private float cd = 0.5f,time;

    // Start is called before the first frame update
    void Awake()
    {
        time = cd;
        playerstatus = GameObject.FindObjectOfType<PlayerStatus>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            playerstatus.TakeDamage(50f);
    }
}
