using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject prefab1;

    void Start()
    {
        Instantiate(prefab1, transform.position, Quaternion.identity);  
    }
}
