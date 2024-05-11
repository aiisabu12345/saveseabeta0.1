using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class butoon1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool isPressed = false;
    public GameObject Player;
    private CharacterController characterController;
    public float speed;
    public ParticleSystem ParticleSystem;
    private Coroutine particleCoroutine;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isPressed)
        {
            // สร้าง Vector3 ที่ชี้ไปทางข้างหน้าของ GameObject
            Vector3 forwardDirection = transform.forward;
            float magnitude = Mathf.Clamp01(forwardDirection.magnitude) * speed;
            forwardDirection.Normalize();

            characterController.SimpleMove(forwardDirection * magnitude);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("ispressed");
        isPressed = true;
        particleCoroutine = StartCoroutine(PlayParticles());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        if (particleCoroutine != null)
        {
            StopCoroutine(particleCoroutine);
        }
        // หยุดเล่น Particle System
        ParticleSystem.Clear();
    }
    IEnumerator PlayParticles()
    {
        // วนลูปเพื่อเล่น Particle System ตลอดเวลา
        while (true)
        {
            ParticleSystem.Play(); // นำ Particle System กลับมาเล่นใหม่
            yield return null;
        }
    }
} 