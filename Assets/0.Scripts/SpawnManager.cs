using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float timer;
    private float startDelay = 2f;
    private float repeatRate;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        repeatRate = Random.Range(1.0f, 2.5f);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            Debug.Log(repeatRate);
            int rand = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[rand], spawnPos, obstaclePrefab[rand].transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= repeatRate)
        {
            SpawnObstacle();
            timer = 0;
            repeatRate = Random.Range(1.0f, 2.5f);
            //Invoke("SpawnObstacle", repeatRate);
        }

    }



    private GameObject obstacle = null;
    public bool isIdle = true;

    void SpawnOb()
    {
        if(playerControllerScript.gameOver == false)
        {
            obstacle = Instantiate(obstaclePrefab[0], spawnPos, obstaclePrefab[0].transform.rotation);
        }
    }

    void Run()
    {
        if(isIdle)
        {
            repeatRate = Random.Range(0, 1.0f);
            Invoke("SpawnOb", repeatRate);
            isIdle = false;
        }

        if(obstacle == null)
        {
            isIdle = true;
        }
    }
}
