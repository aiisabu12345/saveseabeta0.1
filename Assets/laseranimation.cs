using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laseranimation : MonoBehaviour
{
    public Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void startsoultrak()
    {
        _animator.SetTrigger("attack");
    }

    public void soultraking()
    {
        _animator.SetTrigger("soultrak");
    }

    public void stopsoultrak()
    {
        _animator.SetTrigger("stop");
    }
}
