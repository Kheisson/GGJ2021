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

    SpawnManager spawner;
    PlayerMovement player;
    MoveBackground[] moveBackground;
    Coroutine _showPanel;
    Coroutine _guessingTime;
    Sprite correctPP;

    int stageCount = 1;
    int _winningNumber;
    float timeToRemember = 2f;
    int indexToStoreSprite;


    public bool shouldSpawn = true;
    public bool timeToGuess = false;
    public bool wonThisRound = false;
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
    }

    private void Start()
    {
        SavePref.LoadPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        if (HighScore < player.CurrentScore())
        {
            HighScore = player.CurrentScore();
            SavePref.SavePrefs();
        }

        if (timeToGuess == true)
        {
            StoreAnswer();
        }

        if (wonThisRound == true)
            NextStage();
        else
            GameOver();
    }

    public void StartStage()
    {
        indexToStoreSprite = Random.Range(0, 3);
        var thisRoundsSprite = stage[stageCount - 1].sprites[indexToStoreSprite];
        puzzlePieceToRemember.sprite = thisRoundsSprite;
        //Start coroutine show panel
        if (_showPanel != null) { StopCoroutine(_showPanel); }
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
        // Player needs to press qwer to choose correct gate, if wrong game over
        // if right, SO stage advance
        if (_guessingTime != null) { StopCoroutine(_guessingTime); }
        else { _guessingTime = StartCoroutine(GuessTime()); }
    }

    void GameOver()
    {
        // Panel pops out with restart or quit to menu
        // Score of collected items should be kept as high score
    }
    
    void NextStage()
    {
        Debug.Log("YOU WON");
        /*// Advance stage
        stageCount += 1;
        // Reset everything
        StartStage();*/
    }

    void StoreAnswer()
    {
        var input = Input.inputString;
        if(input == _winningNumber.ToString())
        {
            wonThisRound = true;
            Debug.Log("You won");
        }
    }

    IEnumerator ShowPanel()
    {
        // Panel Should PopUP revealing pattern to remember (Popup 2 seconds) and then disabled
        puzzlePopupPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(timeToRemember);
        puzzlePopupPanel.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        // After one seconds the player can move and stuff will start spawning
        player.SetKinematic(false);
        // Spawning should start
        spawner.Spawner(true);
        _winningNumber = gates.GetAndSetWinner(indexToStoreSprite, stageCount);
        Debug.Log(_winningNumber);
    }

    IEnumerator GuessTime()
    {
        gates.gameObject.SetActive(true);
        gates.ShowGate();
        timeToGuess = true;
        yield return new WaitForSecondsRealtime(5f);

        gates.HideGate();
        yield return new WaitForSecondsRealtime(0.5f);
        gates.gameObject.SetActive(false);
    }

    private void Singleton()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }

}

