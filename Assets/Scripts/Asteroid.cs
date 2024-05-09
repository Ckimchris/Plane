using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject Explosion;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
