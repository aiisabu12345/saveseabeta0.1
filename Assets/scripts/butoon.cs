using UnityEngine;
using UnityEngine.EventSystems;

public class butoon : MonoBehaviour
{
    private bool isPressed = false;
    public GameObject Player;
    public Rigidbody rb;
    public float force = 10f;
    public float speed = 10f;


    void Update()
    {
        if (isPressed)
        {
            Vector3 movement = transform.forward * speed * Time.deltaTime;

            // เคลื่อนที่ GameObject ไปข้างหน้าตาม vector ที่หาได้
            transform.Translate(movement);
            // สร้าง Vector3 ที่ชี้ไปทางข้างหน้าของ GameObject
            /*Vector3 forwardDirection = transform.forward;


            rb.AddForce(forwardDirection * force * Time.deltaTime, ForceMode.VelocityChange);*/
        }
    }

    public void OnPointerDown()
    {
        isPressed = true;

    }

    public void OnStopButtonClick()
    {
        isPressed = false;
    }
}