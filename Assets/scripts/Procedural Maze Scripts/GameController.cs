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
        
        audioSource.PlayOneShot(success);
        Invoke("LoadSceneWin",2f);
    }
    

    void LoadSceneWin() {
        // Call coroutine to delay loading winscene for 3 seconds, giving
        // sound effect full time to play
        StartCoroutine(DelayedEnd());
    }


    // Coroutine to delay for 3 seconds
    IEnumerator DelayedEnd() {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("WinScene");
        Cursor.visible = true;
        generator.DisposeOldMaze();
        player.enabled = false;
    }
}