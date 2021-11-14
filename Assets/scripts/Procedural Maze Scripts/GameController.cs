using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private uint score = 0;

    // MazeConstructor initialized, sets up for new game to begin and then
    // starts maze generation and game
    void Start() {
        Debug.Log("Test");
        generator = GetComponent<MazeConstructor>();
        player = GameObject.Find("Player Character").GetComponent<FpsMovement>();

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
    }


    void Update() {

    }


    // Callback function, passed to TriggerEventRouter in MazeConstructor
    // Triggered when goal is found and collided with
    private void OnGoalTrigger(GameObject trigger, GameObject other) {
        Debug.Log("Finished!");
        
        Destroy(trigger);
        // Play goal "get" sound
        score++;

        generator.DisposeOldMaze();

        rows += 4;
        cols += 4;
        StartNewMaze();
        // Add timer reset/increase time limit code here
    }
}