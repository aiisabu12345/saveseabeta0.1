using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BossAttack : MonoBehaviour
{
    public PlayerStatus playerstatus;
    public BossStatus bossstatus;
    public GameObject shootpoint;
    public BossSoultrak bosssoultrak;

    //delaydamge
    public float cd = 0.5f, time = 0f;

    //laser
    [SerializeField] ParticleSystem beam = null;
    public Animator _animator;

    //phaseattack
    bool alreadysoultrak = false;

    void Awake()
    {
        time = cd;
        playerstatus = GameObject.FindObjectOfType<PlayerStatus>();
        bosssoultrak = GameObject.FindObjectOfType<BossSoultrak>();
        bossstatus = GameObject.FindObjectOfType<BossStatus>();
        shootpoint = GameObject.Find("shootpoint");
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(bossstatus.currentHealth <= (bossstatus.maxHealth / 100) * 25 )
        {
            _animator.SetTrigger("fire");
        }

        if(bossstatus.currentHealth <= (bossstatus.maxHealth / 100) * 50 && !alreadysoultrak)
        {
            beam.Play();
            _animator.SetTrigger("soultrak");
            bosssoultrak.Startsoultrak();
            alreadysoultrak = true;
        }

        if (alreadysoultrak && time <= 7.2f)
        {
            transform.Rotate(0, 50 * Time.deltaTime, 0);
            time += Time.deltaTime;
        }

        if(time >= 7.2f && time <= 8f)
        {
            beam.Stop();
            _animator.SetTrigger("idle");
            bosssoultrak.stopsoultrak();
        }
    }
}
