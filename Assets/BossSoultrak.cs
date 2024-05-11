using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSoultrak : MonoBehaviour
{
    public GameObject laser;
    private bool start = false;

    public void Startsoultrak()
    {
        laser.gameObject.SetActive(true);
    }

    public void stopsoultrak()
    {
        laser.gameObject.SetActive(false);
    }
}
