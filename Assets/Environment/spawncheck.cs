using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncheck : MonoBehaviour
{
    public GameObject sharkspawn;
    public GameObject takospawn;

    public int shark = 0;
    public int tako = 0;

    void Start()
    {
        sharkcheck();
        takocheck();
    }

    public void sharkcheck()
    {
        shark = PlayerPrefs.GetInt("shark",0);
        if(shark == 1)
        {
            sharkspawn.SetActive(false);
        }
    }

    public void takocheck()
    {
        tako = PlayerPrefs.GetInt("tako",0);
        if(tako == 1)
        {
            takospawn.SetActive(false);
        }
    }
}
