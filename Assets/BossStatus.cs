using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    public ParticleSystem boom = null;
    public float maxHealth;
    public float currentHealth;
    public GameObject hpbar;
    public HealthBar healthBar;
    public Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(Playerupgradevalue.damage);
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            TakeDamage(750f);
        }

        if (currentHealth <= 0)
        {
            _animator.SetTrigger("boom");
            Invoke(nameof(DestroyEnemy), 3f);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }

    private void DestroyEnemy()
    {
        boom.Play();
        hpbar.SetActive(false);
        Destroy(gameObject, 0.17f);
    }

}
