using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlane : PlaneController
{
    private float cooldown;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player(Clone)");
    }

    // Update is called once per frame
    void Update()
    {

        cooldown += Time.deltaTime;
        if (cooldown >= 5f)
        {
            if(target != null)
            {
                if (Vector3.Distance(gameObject.transform.position, target.transform.position) < 20f)
                {
                    Fire();
                    cooldown = 0;
                }
            }

        }

        if(target != null)
        {
            if (Vector3.Distance(gameObject.transform.position, target.transform.position) < 50f)
            {
                Brake();
            }
            else
            {
                Accelerate();
            }
        }


        throttle = Mathf.Clamp(throttle, 50f, 70f);

    }

    public void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        if (target != null)
        {
            rb.AddTorque(transform.up * GetXAngle() * sensitivity / 5f);
            rb.AddTorque(transform.right * GetYAngle() * sensitivity / 5f);
        }

    }

    //find player
    //fly toward's player's behind
    //stay in vicinity of player
    //match player movement

    void Accelerate()
    {
        throttle += throttleIncrement;
    }

    void Brake()
    {
        throttle -= throttleIncrement;
    }

    public float GetXAngle()
    {
        Vector3 direction = target.transform.position - gameObject.transform.position;
        float angle = Vector3.SignedAngle(direction, transform.up, transform.forward);
        return angle;
    }

    public float GetYAngle()
    {
        Vector3 direction = target.transform.position - gameObject.transform.position;
        float angle = Vector3.SignedAngle(direction, transform.right, transform.forward);
        return angle;
    }
}
