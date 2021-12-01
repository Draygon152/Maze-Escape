using UnityEngine;
using TMPro;


[RequireComponent(typeof(MazeConstructor))]


public class GameController : MonoBehaviour {
    // Player object using FpsMovement script
    private FpsMovement player;

    // AudioSource object that plays sound when a "goal" is reached/collected
    [SerializeField] private AudioSource scoreIncrease;

    // MazeConstructor generator object, to be used when game starts
    private MazeConstructor generator;

    // Default maze generation size, increased each time player advances
    private uint rows = 13;
    private uint cols = 15;

    // Stores the number of goals that have been collected
    public uint score = 0;

    // Text object that displays the score and updates when a goal is reached
    public TextMeshProUGUI scoreText;

    bool goalReached = false;


    // MazeConstructor initialized, sets up for new game to begin and then
    // starts maze generation and game
    void Start() {
        generator = GetComponent<MazeConstructor>();
        player = GameObject.Find("Player Character").GetComponent<FpsMovement>();

        BeginMaze();
    }


    void Update() {
        if (!player.enabled) return;
    }


    private void BeginMaze() {
        StartNewMaze();
    }


    // Generates new maze and instantiates player
    private void StartNewMaze() {
        generator.GenerateNewMaze(ref rows, ref cols, OnGoalTrigger);

        float x = generator.startCol * generator.hallWidth;
        float y = 1;
        float z = generator.startRow * generator.hallWidth;

        // Places player in start of maze
        player.transform.position = new Vector3(x, y, z);

        player.enabled = true;
    }



    // Callback function, passed to TriggerEventRouter in MazeConstructor
    // Triggered when goal is found and collided with
    private void OnGoalTrigger(GameObject trigger, GameObject other) {
        player.enabled = false;
        Debug.Log("Finished!");

        scoreIncrease.Play();
        score++;
        scoreText.text = $"Gems: {score} / 8";
        Destroy(trigger);
        
        generator.DisposeOldMaze();

        rows += 2;
        cols += 2;
        StartNewMaze();

        // Add timer reset/increase time limit code here
    }
}