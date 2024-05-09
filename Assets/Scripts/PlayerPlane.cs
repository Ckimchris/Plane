using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlane : PlaneController
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        roll = Input.GetAxis("Horizontal");
        pitch = Input.GetAxis("Vertical");
        yaw = Input.GetAxis("Yaw");

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Fire();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            throttle += throttleIncrement;
            thrustAudio.Play();
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            throttle -= throttleIncrement;
        } 

        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    public void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * sensitivity / 2f);
        rb.AddTorque(transform.right * pitch * sensitivity);
        rb.AddTorque(-transform.forward * roll * sensitivity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        Instantiate(audioClipObj, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameManager.Instance.RestartGame(2f);

    }
}
