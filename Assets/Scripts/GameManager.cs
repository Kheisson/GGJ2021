using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<SO_Stage> stage;
    SpawnManager spawner;
    int stageCount = 1;

    public bool shouldSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            spawner.Spawner(shouldSpawn);
            shouldSpawn = !shouldSpawn;
        }
    }

    void StartStage()
    {
        // Panel Should PopUP revealing pattern to remember (Popup 2 seconds) and then disabled
        // Background starts moving
        // Player gravity set to true
        // Start spawning
    }

    void EndStage()
    {
        // Gravity set to false
        // Move Background stops
        // Spawning should stop
        // Gates appear
        // Player needs to press qwer to choose correct gate, if wrong game over
        // if right, SO stage advance
    }
    void GameOver()
    {
        // Panel pops out with restart or quit to menu
        // Score of collected items should be kept as high score
    }

}
