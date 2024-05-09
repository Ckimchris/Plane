using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject audioClipObj;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * 400f);

        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(audioClipObj, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
