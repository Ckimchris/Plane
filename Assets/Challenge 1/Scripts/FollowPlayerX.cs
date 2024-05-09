using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public Transform povs;
    public float speed = 50f;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if(povs != null)
        {
            target = povs.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(povs != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            transform.rotation = povs.rotation;
        }

    }


}
