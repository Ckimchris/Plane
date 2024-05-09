using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCamera : MonoBehaviour
{
    [SerializeField]
    new Camera camera;
    [SerializeField]
    Vector3 cameraOffset;
    [SerializeField]
    Vector2 lookAngle;
    [SerializeField]
    float movementScale;
    [SerializeField]
    float lookAlpha;
    [SerializeField]
    float movementAlpha;
    [SerializeField]
    Vector3 deathOffset;
    [SerializeField]
    float deathSensitivity;

    Transform cameraTransform;
    PlayerPlane plane;
    Transform planeTransform;
    Vector2 lookInput;
    bool dead;

    Vector2 look;
    Vector2 lookAverage;
    Vector3 avAverage;

    void Awake()
    {
        cameraTransform = camera.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlane(PlayerPlane plane)
    {
        this.plane = plane;

        if (plane == null)
        {
            planeTransform = null;
        }
        else
        {
            planeTransform = plane.GetComponent<Transform>();
        }

        cameraTransform.SetParent(planeTransform);
    }

    public void SetInput(Vector2 input)
    {
        lookInput = input;
    }
}
