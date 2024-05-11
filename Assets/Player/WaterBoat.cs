using Ditzelgames;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(WaterFloatxd))]
public class WaterBoat : MonoBehaviour
{
    public Transform Motor;
    public float SteerPower = 400f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;
    //public BoatControllerUI boatControllerUI;
    //public float MaxSpeed { get; set; }
    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;
    protected ParticleSystem ParticleSystem;
    protected Camera Camera;
    private bool isMovingForward = false;
    private bool isMovingA = false;
    private bool isMovingD = false;

    protected Vector3 CamVel;
    public float speed = 3f;


    public void StartMovingForward()
    {
        isMovingForward = true;

    }

    public void Awake()
    {
        
        ParticleSystem = GetComponentInChildren<ParticleSystem>();
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
        Camera = Camera.main;
        MaxSpeed = Playerupgradevalue.maxSpeed;
    }
    public void StopMoving()
    {
        isMovingForward = false;

        // เรียกใช้ slowdowncoroutine
        StartCoroutine(SlowDownCoroutine());

    }
    public void FixedUpdate()
    {
        var steer = 0;
        if (isMovingForward)
        {
            var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
            var targetVel = Vector3.zero;


            PhysicsHelperxd.ApplyForceToReachVelocity(Rigidbody, forward * MaxSpeed, Power);
            var movingForward = Vector3.Cross(transform.forward, Rigidbody.velocity).y < 0;

            //move in direction
            Rigidbody.velocity = Quaternion.AngleAxis(Vector3.SignedAngle(Rigidbody.velocity, (movingForward ? 1f : 0f) * transform.forward, Vector3.up) * Drag, Vector3.up) * Rigidbody.velocity;
        }
        if (isMovingA)
        {
            steer = 1;

        }
        if (isMovingD)
        {
            steer = -1;

        }
        Rigidbody.AddForceAtPosition(steer * transform.right * SteerPower / 100f, Motor.position);
    }
    public void MoveBackward()
    {

        var backward = Vector3.Scale(new Vector3(1, 0, 1), -transform.forward);
        PhysicsHelperxd.ApplyForceToReachVelocity(Rigidbody, backward * MaxSpeed, Power);
    }
    public void SteerLeft()
    {
        //isMovingA = true;
        Rigidbody.AddTorque(Vector3.up * -SteerPower);
        var forceDirection = transform.forward;
        //var steer = 1;
    }

    public void SteerRight()
    {
        //isMovingD = true;
        Rigidbody.AddTorque(Vector3.up * SteerPower);
        var forceDirection = transform.forward;
        //var steer = 1;
    }
    public void StopAD()
    {
        Rigidbody.angularVelocity = Vector3.zero;
    }
    private IEnumerator SlowDownCoroutine()
    {
        while (Rigidbody.velocity.magnitude > 0.1f)
        {
            // ลดความเร็วอย่างค่อยๆ
            Rigidbody.velocity *= 0.9f; // หรือใช้ค่าอื่นๆ ที่เหมาะสม

            yield return new WaitForSeconds(0.1f); // รอเวลาเพื่อลดความเร็วอย่างค่อยๆ
        }

        // ตั้งค่าความเร็วเป็นศูนย์เมื่อเรือหยุด
        Rigidbody.velocity = Vector3.zero;
    }

    /* private IEnumerator SlowDownAD()
     {
        while (Rigidbody.velocity.magnitude > 0.1f)
         {
             // ลดความเร็วอย่างค่อยๆ
             Rigidbody.velocity *= 1f; // หรือใช้ค่าอื่นๆ ที่เหมาะสม

             yield return new WaitForSeconds(0.1f); // รอเวลาเพื่อลดความเร็วอย่างค่อยๆ
         }

         // ตั้งค่าความเร็วเป็นศูนย์เมื่อเรือหยุด
         Rigidbody.velocity = Vector3.zero;
         Rigidbody.angularVelocity = Vector3.zero;
     }*/
    
}
