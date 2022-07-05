using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    //Private variables
    public GameObject[] obstaclePrefab;
    public GameObject coinPrefab;
    public GameObject nitroPrefab;
    private float zRange = 20;
    private float xRange = 8;
    public float spawnInterval = 3.0f;  // default spawn rate = one every 2 seconds
    private float spawnTimeLeft;
    public TextMeshProUGUI speedText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.speedCount = 1;
        //repeatedly spawn objects with different interval of time in seconds 
        InvokeRepeating("SpawnCoin", 5, 10);
        InvokeRepeating("SpawnNitro", 10, 50);

        StartCoroutine("IncreaseDifficulty");
    }

    // Update is called once per frame
    void Update()
    {

        //stop the spawnmanager when the game is over
        if(GameManager.isGameOver)
        {
            Destroy(gameObject);
        }
        else
        {
            // spawning logic
            spawnTimeLeft -= Time.deltaTime * GameManager.speedCount; // higher speed count = faster spawns;
            while (spawnTimeLeft < 0.0f) 
            {
                spawnTimeLeft += spawnInterval;
                SpawnObstacle();
            }
        }

        speedText.text = "Speed : "+GameManager.speedCount;
    }

    //increase the difficulty of the game by increasing the speed count
    IEnumerator IncreaseDifficulty()
    {
        while(!GameManager.isGameOver)
        {
            yield return new WaitForSeconds(10);
            GameManager.speedCount++;
        }
    }

    //instantiate obstacles at a specific location
    private void SpawnObstacle(/*int cordX*/)
    {
        int index = randomIndex();
        Instantiate(obstaclePrefab[index], GenerateSpawnPosition(RandomXRange()), obstaclePrefab[index].transform.rotation);
    }
    //instantiate coins at a random location
    private void SpawnCoin()
    {
        Instantiate(coinPrefab, GenerateSpawnPosition(RandomXRange()), coinPrefab.transform.rotation);
    }
    //instantiate nitro at a random location
    private void SpawnNitro()
    {
        Instantiate(nitroPrefab, GenerateSpawnPosition(RandomXRange()), nitroPrefab.transform.rotation);
    }
    //generate a random x range
    private int RandomXRange()
    {
        return (int)Random.Range(-xRange,xRange);
    }
    
    //create the vector position
    private Vector3 GenerateSpawnPosition(int cordX)
    {
        return new Vector3(cordX,0.5f,zRange);
    }

    //generate random index
    private int randomIndex()
    {
        return Random.Range(0, obstaclePrefab.Length);
    }
}
