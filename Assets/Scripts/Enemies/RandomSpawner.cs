/* Author: James */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public GameObject cubePrefab;
    public float rangeX1, rangeX2, rangeY, rangeZ1, rangeZ2;
    public static int wave = 1;
    public static int enemiesNum = 0;
    public bool waveOver = true;
    public int numSet;
    void Update()
    {

        if (waveOver)
        {

            for (int i = 0; i < wave * numSet; i++)
            {

                Vector3 randomSpawnPosition = new Vector3(Random.Range(rangeX1, rangeX2), rangeY, Random.Range(rangeZ1, rangeZ2));
                Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
                enemiesNum++;


            }
            waveOver = false;
            Destroyed();

        }

    }

    void Destroyed()
    {

        if (enemiesNum == 0)
        {

            waveOver = true;
            Debug.Log("Wave " + wave);

        }

    }

}
