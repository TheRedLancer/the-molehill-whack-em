using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoleSpawn : MonoBehaviour
{
    public GameObject molePrefab;
    public Transform spawnPoint;
    public bool doSpawn = false;

    Vector3 randSpawnPoint;
    public float minRangex = -6f;
    public float maxRangex = 7f;
    public float minRangey = -3.5f;
    public float maxRangey = 4f;
    public float nextSpawnTime = 0f;
    static public float spawnRate = 0.7f;
    public int startMoles = 12;
    public GameObject enterText;
    public GameObject youWinText;
    public GameObject tilemap;
    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < startMoles; i++)
        {
            randSpawnPoint = new Vector3(Random.Range(minRangex, maxRangex), Random.Range(minRangey, maxRangey), 0);
            Instantiate(molePrefab, randSpawnPoint, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Start"))
        {
            doSpawn = true;
            enterText.SetActive(false);
            tilemap.SetActive(false);
        }
        if (FindObjectOfType<Enemy>())
        {
            if (doSpawn && Time.time >= nextSpawnTime && FindObjectsOfType<Enemy>().Length < 31)
            {
                spawnMole();
            }
        } else
        {
            youWin();
        }
    }

    void spawnMole()
    {
        randSpawnPoint = new Vector3(Random.Range(minRangex, maxRangex), Random.Range(minRangey, maxRangey), 0);
        Instantiate(molePrefab, randSpawnPoint, Quaternion.identity);
        nextSpawnTime = Time.time + 1f / spawnRate;
    }

    void youWin()
    {
        youWinText.SetActive(true);
        restartButton.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void restartGame()
    {
        doSpawn = false;
        enterText.SetActive(true);
        tilemap.SetActive(true);
        youWinText.SetActive(false);
        restartButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

