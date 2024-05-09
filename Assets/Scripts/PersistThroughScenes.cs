using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistThroughScenes : MonoBehaviour
{

    public static PersistThroughScenes Instance { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
