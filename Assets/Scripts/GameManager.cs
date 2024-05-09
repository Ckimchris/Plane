using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    private GameObject player;
    public GameObject playerPrefab;
    private GameObject enemy;
    public GameObject enemyPrefab;
    public Camera mainCamera;
    public Transform asteroid;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenuCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartGame(0f);
        }
    }

    void CreateAsteroidField(int count)
    {
        for(int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    void CreateObject()
    {
        Transform t = Instantiate(asteroid);
        t.localPosition = new Vector3(Random.Range(-250f, 250f), Random.Range(0f, 50f), Random.Range(-250f, 250f));
        t.localRotation = Random.rotation;
        t.localScale = Vector3.one * Random.Range(1, 5f);
    }

    public void StartFreePlay()
    {
        SpawnPlayer();
        AttachCamera();
        CreateAsteroidField(500);
        mainMenuCanvas.gameObject.SetActive(false);

    }

    public void StartCPUGame()
    {
        SpawnPlayer();
        AttachCamera();
        SpawnEnemies();
        CreateAsteroidField(500);
        mainMenuCanvas.gameObject.SetActive(false);

    }

    public void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, new Vector3(0, 100, 0), Quaternion.identity);
    }

    public void AttachCamera()
    {
        mainCamera.GetComponent<FollowPlayerX>().povs = player.transform.Find("CameraAnchor");
    }

    public void SpawnEnemies()
    {
        enemy = Instantiate(enemyPrefab, new Vector3(0, 100, 100), Quaternion.identity);

    }

    public void RestartGame(float time)
    {
        StartCoroutine(RestartAfterTime(time));

    }

    public IEnumerator RestartAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
