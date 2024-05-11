using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxStamina;

    private float currentHealth;
    private float currentStamina;

    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public GameOver gameover;
    public bool attaked = false;
    public float cd_shield = 3f, time_shield;
    public float shieldtime = 3f;

    public bool useForceField = false;
    public bool isgameover = false;
    public float timeoffield = 5f;

    private void Start()
    {
        Time.timeScale = 1;
        isgameover = false;
        cd_shield = time_shield;

        maxHealth = Playerupgradevalue.maxHp;

        currentHealth = maxHealth;
        currentStamina = maxStamina;

        healthBar.SetSliderMax(maxHealth);
        staminaBar.SetSliderMax(maxStamina);
    }



    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "enemybullet")
        {
            TakeDamage(10f);
        }
    }

    private void LateUpdate()
    {

        if (currentHealth <= 0)
        {
            gameover.Setup();
            isgameover = true;
            Time.timeScale = 0;

        }
    }

    public void TakeDamage(float amount)
    {
        if (!useForceField)
        {
            currentHealth -= amount;
            healthBar.SetSlider(currentHealth);
        }
    }

    private void UseStamina(float amount)
    {
        currentStamina -= amount * Time.deltaTime;
        staminaBar.SetSlider(currentHealth);
    }

    void Update()
    {
        cd_shield -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(100f);
        }
    }

    public void StartForceField()
    {
        if (!useForceField)
        {
            useForceField = true;
            Invoke("stopForceField", timeoffield);
        }
    }

    public void stopForceField()
    {
        useForceField = false;
    }

}
