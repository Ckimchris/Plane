using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPlane : PlaneController
{
    Ray ray;
    RaycastHit raycastHit;
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
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out raycastHit))
        {

        }
        else
        {

        }

        cooldown += Time.deltaTime;
        if (cooldown >= 5f)
        {
            if (Vector3.Distance(gameObject.transform.position, target.transform.position) < 10f)
            {
                Fire();
                cooldown = 0;
            }
        }

        if (Vector3.Distance(gameObject.transform.position, target.transform.position) < 50f)
        {
            Brake();
        }
        else
        {
            Accelerate();
        }

        throttle = Mathf.Clamp(throttle, 50f, 100f);

    }

    public void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        //rb.AddTorque(GetAngle() * sensitivity / 2f);
        rb.AddTorque(transform.up * GetXAngle() * sensitivity/5f);
        rb.AddTorque(transform.right * GetYAngle() * sensitivity/5f);
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

    public Vector3 GetAngle()
    {
        Vector3 direction = target.transform.position - gameObject.transform.position;
        return direction;
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
