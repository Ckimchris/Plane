using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    protected float throttleIncrement = 0.1f;
    protected float maxThrust = 200f;
    protected float sensitivity = 5f;
    protected float lift = 135f;
    public float throttle = 50f;
    protected float roll;
    protected float pitch;
    protected float yaw;
    protected Rigidbody rb;
    public AudioSource thrustAudio;
    public AudioSource deathAudio;
    public GameObject Bullet;
    public Transform Emitter;
    public GameObject Explosion;
    public GameObject audioClipObj;

    protected float responseModifier
    {
        get
        {
            return (rb.mass / 10f) * sensitivity;
        }
    }

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Fire()
    {
        Instantiate(Bullet, Emitter);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
