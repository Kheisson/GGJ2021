using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnables;

    void SpawnObjects()
    {
        int randomIndex = Random.Range(0, spawnables.Length);
        Vector3 spawnPos = new Vector3(15.5f, Random.Range(-4, 7), 0);
        Instantiate(spawnables[randomIndex], spawnPos, Quaternion.identity);
    }
   
    IEnumerator SpawnControl()
    {
        while (true)
        {
            SpawnObjects();
            yield return new WaitForSeconds(2f); ;
        }
    }

    public void Spawner(bool shouldSpawn)
    {
        if (shouldSpawn)
            StartCoroutine(SpawnControl());
        else
            StopAllCoroutines();
    }
}
