using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float acceleration;
    public float yawSpeed;
    public float rotationSpeed;
    public float pitchSpeed;
    private float verticalInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move the plane forward at a constant rate
        //transform.Translate(Vector3.forward * speed * (Time.deltaTime));

        if (Input.GetKey(KeyCode.I))
        {
            Thrust(1f);
        }
        if (Input.GetKey(KeyCode.K))
        {
            Thrust(-1f);
        }
        if (Input.GetKey(KeyCode.J))
        {
            Rotate(Vector3.down, yawSpeed);
        }
        if (Input.GetKey(KeyCode.L))
        {
            Rotate(Vector3.up, yawSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Rotate(Vector3.right, pitchSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Rotate(Vector3.left, pitchSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Rotate(Vector3.forward, rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rotate(Vector3.back, rotationSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.eulerAngles = Vector3.zero;
        }

    }

    public void Thrust(float thrustVal)
    {
        acceleration += thrustVal;
        if (acceleration > 20)
        {
            acceleration = 20;
        }
        if (acceleration < 5)
        {
            acceleration = 5;
        }
    }

    public void Yaw(Vector3 dir, float yawVal)
    {
        if(transform.rotation.y > 2f)
        {
            transform.Rotate(0, 2f, 0);
        }
        if(transform.rotation.y < -2f)
        {
            transform.Rotate(0, -2f, 0);

        }

        transform.Rotate(dir * yawSpeed * Time.deltaTime);
    }

    public void Rotate(Vector3 dir, float speed)
    {
        transform.Rotate(dir * speed * Time.deltaTime);
    }

    public void LevelPlane()
    {

    }

    public IEnumerator LerpRotation()
    {
        yield return null;
    }
}
