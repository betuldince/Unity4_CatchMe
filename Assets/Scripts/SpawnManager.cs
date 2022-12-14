using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject powerUp;
    private float spawnRange=9;
    private int WaveNum=1;
    public int remainingEnemy;

     
    void Start()
    {
        EnemySpawner(WaveNum);
        Instantiate(powerUp, RandomPosition(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        remainingEnemy = GameObject.FindObjectsOfType<Enemy>().Length;
        if (remainingEnemy == 0 && GameManager.Instance.gameOver == false)
        {
            WaveNum++;
            EnemySpawner(WaveNum);
            Instantiate(powerUp, RandomPosition(), Quaternion.identity);
        }
 
    }
    private Vector3 RandomPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnX, 0, spawnZ);
    }
    void EnemySpawner(int enemyNum)
    {
        for(int i = 0; i < enemyNum; i++)
        {
            Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity);
        }
    }
}
