using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnables;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", 1, 2);
    }

    void SpawnObjects()
    {
        int randomIndex = Random.Range(0, spawnables.Length);
        Vector3 spawnPos = new Vector3(15.5f, Random.Range(-4, 7), 0);
        Instantiate(spawnables[randomIndex], spawnPos, Quaternion.identity);
    }
}
