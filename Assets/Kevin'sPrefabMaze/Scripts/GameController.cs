using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MazeConstructor))]

public class GameController : MonoBehaviour {
    // Player object using FpsMovement script
    [SerializeField] private FpsMovement player;
    [SerializeField] AudioClip success;  //play auidoclip
    AudioSource audioSource;

    // MazeConstructor generator object, to be used when game starts
    private MazeConstructor generator;

    // MazeConstructor initialized, sets up for new game to begin and then
    // starts maze generation and game
    void Start() {
        audioSource = GetComponent<AudioSource>();
        generator = GetComponent<MazeConstructor>();
        Cursor.visible = false;
        
        StartNewMaze();
    }


    // Generates new maze and instantiates player
    private void StartNewMaze() {
        uint rows = 13;
        uint cols = 15;
        generator.GenerateNewMaze(ref rows, ref cols, OnGoalTrigger);

        float x = generator.startCol * generator.hallWidth;
        float y = 1;
        float z = generator.startRow * generator.hallWidth;

        // Places player in start of maze
        player.transform.position = new Vector3(x, y, z);

        player.enabled = true;
    }


    // Checks if player is still active
    void Update() {
        if (!player.enabled) { return; }
    }


    // Callback function, passed to TriggerEventRouter in MazeConstructor
    // Triggered when goal is found and collided with
    private void OnGoalTrigger(GameObject trigger, GameObject other) {
        Debug.Log("Finished!");
        
        Destroy(trigger);
        
        // Replace with scene switch to victory before cleanup
        player.enabled = false; // kind of awkward of being freezed for 3 sec
        //StartCoroutine(DelayedEnd()); // edit to switch scene
        audioSource.PlayOneShot(success);
        Invoke("LoadSceneWin",3f);
    }
    
    void LoadSceneWin()
    {
        // load the win scene
        
        SceneManager.LoadScene("scene win");
        generator.DisposeOldMaze();
    }


    IEnumerator DelayedEnd() {
        yield return new WaitForSeconds(5);

        // Dispose of maze after victory
        generator.DisposeOldMaze();
        Application.Quit();
    }
}