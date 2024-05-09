using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayAltitude : MonoBehaviour
{
    public PlayerPlane playerPlane;
    private TextMeshProUGUI text;
    private float altitude;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        altitude = Mathf.Round(playerPlane.gameObject.transform.position.y);

        text.text = altitude.ToString() + ":Altitude";
    }
}
