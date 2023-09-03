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
        rangeX1 = player.transform.position.x - 50;
        rangeX2 = player.transform.position.x + 50;
        rangeZ1 = player.transform.position.z - 50;
        rangeZ2 = player.transform.position.z + 50;
    }

    void Update()
    {
        if (Timers.IsTimerFinished("SpawnTimer" + cubePrefab.name))
        {
            waveOver = false;
            for (int i = 0; i < wave * numSet; i++)
            {

                Vector3 randomSpawnPosition = new Vector3(Random.Range(rangeX1, rangeX2), rangeY, Random.Range(rangeZ1, rangeZ2));
                Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
                enemiesNum++;


            }
            Timers.SetTimer("SpawnTimer" + cubePrefab.name, spawnPerSecs);
        }

    }

}
