using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<SO_Stage> stage;
    [SerializeField] GameObject puzzlePopupPanel;
    [SerializeField] Image puzzlePieceToRemember;
    [SerializeField] PuzzlePanel gates;
    [SerializeField] Sprite otherPP;

    SpawnManager spawner;
    PlayerMovement player;
    MoveBackground[] moveBackground;
    Coroutine _showPanel;

    //int stageCount = 1;
    float timeToRemember = 2f;

    public bool shouldSpawn = true;
    public int HighScore = 0;
    public static GameManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        Singleton();
        spawner = GameObject.FindObjectOfType<SpawnManager>();
        player = GameObject.FindObjectOfType<PlayerMovement>();
        moveBackground = FindObjectsOfType<MoveBackground>();
        Debug.Log(puzzlePieceToRemember.sprite.name);
        puzzlePieceToRemember.sprite = otherPP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HighScore < player.CurrentScore())
        {
            HighScore = player.CurrentScore();
        }
    }

    public void StartStage()
    {
        //Start coroutine show panel
        if(_showPanel != null) { StopCoroutine(_showPanel); }
        else { _showPanel = StartCoroutine(ShowPanel()); }
        // Background starts moving
        foreach (var image in moveBackground)
            image.shouldMove = true;
    }

    public void EndStage()
    {
        // Gravity set to false
        player.SetKinematic(true);
        // Spawning should stop and be destroyed
        spawner.Spawner(false);
        spawner.DestroyAllSpawnables();
        // Gates appear
        gates.ShowGate();
        // Player needs to press qwer to choose correct gate, if wrong game over
        // if right, SO stage advance
    }

    void GameOver()
    {
        // Panel pops out with restart or quit to menu
        // Score of collected items should be kept as high score
    }

    IEnumerator ShowPanel()
    {
        // Panel Should PopUP revealing pattern to remember (Popup 2 seconds) and then disabled
        puzzlePopupPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(timeToRemember);
        puzzlePopupPanel.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        // After one seconds the player can move and stuff will start spawning
        player.SetKinematic(false);
        // Spawning should start
        spawner.Spawner(true);
    }

    private void Singleton()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }

}

