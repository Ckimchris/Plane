using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayThrottle : MonoBehaviour
{
    public PlayerPlane playerPlane;
    private TextMeshProUGUI text;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
       text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Round(playerPlane.throttle);

        text.text = "Speed: " + speed.ToString();
    }
}
