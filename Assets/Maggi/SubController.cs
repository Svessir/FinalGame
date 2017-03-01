using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubController : MonoBehaviour
{
    public float maxSpeed = 10;
    public float acceleration = 10;
    public float drag = 0.3f;
    public float gyroSpeed = 1;
    public GameObject spotLight;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        ProcessInput();
        ProcessMouse();
        GyroscopicCorrection();
    }

    void ProcessInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 dir = Vector2.zero;
        if (Mathf.Abs(x) > 0.05f || Mathf.Abs(y) > 0.05f)
        {
            dir = new Vector2(x, y).normalized;
        }
        Move(dir);
    }

    void Move(Vector2 dir)
    {
        Vector3 vel = rb.velocity;
        if (dir.magnitude < 0.5 || Vector3.Angle(dir, vel) > 90)
        {
            vel = vel - (vel * drag * Time.deltaTime);
        }
        vel = vel + new Vector3(dir.x, dir.y, 0) * Time.deltaTime * acceleration;
        if (vel.magnitude > maxSpeed)
        {
            vel = vel.normalized * maxSpeed;
        }
        rb.velocity = vel;
    }

    void ProcessMouse()
    {
   

    }

    //behaves weirdly when sub is turned more than 90 degrees
    void GyroscopicCorrection()
    {
        float rotAngleZ = Quaternion.Angle(this.transform.rotation, Quaternion.Euler(Vector3.right));

        Quaternion target;

        if (rotAngleZ <= 90)
        {
            target = Quaternion.Euler(Vector3.forward);
        }
        else
        {
            //Debug.Log("2");
            target = Quaternion.Euler(Vector3.back);
        }

        //Debug.Log(rotAngleZ);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, target, gyroSpeed));
    }
}

