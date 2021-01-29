using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnables;
    Coroutine spawnCoroutine;

    void SpawnObjects()
    {
        int randomIndex = Random.Range(0, spawnables.Length);
        Vector3 spawnPos = new Vector3(14, Random.Range(-1.5f, 2.6f), 0);
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
        if (shouldSpawn == true) 
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }
            else
            {
                spawnCoroutine = StartCoroutine(SpawnControl()); 
            }
        } 
        else 
        { 
            StopCoroutine(spawnCoroutine); 
        }
    }

    public void DestroyAllSpawnables()
    {
        MoveLeft[] allSpawnables = GameObject.FindObjectsOfType<MoveLeft>();
        foreach (var spawnedItem in allSpawnables)
            Destroy(spawnedItem.gameObject);
    }
}
