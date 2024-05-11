using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour
{
    public float spawncountdown, timetospawn;

    public GameObject prefab1;
    void Start()
    {
        spawncountdown = timetospawn;
        Instantiate(prefab1, transform.position, Quaternion.identity);  
    }

    // Update is called once per frame
    void Update()
    {
        spawncountdown -= Time.deltaTime;
        if(spawncountdown <= 0)
        {
            Instantiate(prefab1, transform.position, Quaternion.identity);
            spawncountdown = timetospawn;
            Debug.Log("Spawn");
        }   
    }
}

