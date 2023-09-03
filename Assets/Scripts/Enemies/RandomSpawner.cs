/* Author: James */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public GameObject cubePrefab;
    public GameObject player;
    private float rangeX1, rangeX2, rangeY, rangeZ1, rangeZ2;

    public static int wave = 1;
    public static int enemiesNum = 0;
    public bool waveOver = true;
    public int numSet;
    public float spawnPerSecs = 5f;

    private void Start()
    {
        rangeX1 = player.transform.position.x - 100;
        rangeX2 = player.transform.position.x + 100;
        rangeZ1 = player.transform.position.z - 100;
        rangeZ2 = player.transform.position.z + 100;
    }

    void Update()
    {
        Debug.Log("Enemies Num = " + enemiesNum);
        //Timers.IsTimerFinished("SpawnTimer" + cubePrefab.name) && 
        if (waveOver)
        {
            Debug.Log("Wave " + wave);
            waveOver = false;
            enemiesNum = wave * numSet;
            for (int i = 0; i < enemiesNum; i++)
            {
                Debug.Log(cubePrefab);
                Vector3 randomSpawnPosition = new Vector3(Random.Range(rangeX1, rangeX2), rangeY, Random.Range(rangeZ1, rangeZ2));
                Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);

            }
            Timers.SetTimer("SpawnTimer" + cubePrefab.name, spawnPerSecs);
            wave++;
        }

    }

    public void Damaged()
    {

        enemiesNum--;
        Debug.Log("Enemies left " + enemiesNum);
        if (enemiesNum == 0)
        {
            waveOver = true;
            Debug.Log("WaveOver");
        }

    }

}
