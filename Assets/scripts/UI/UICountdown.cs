using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.SceneManagement;

public class UICountdown : MonoBehaviour
{
    private FpsMovement player;
    private int timeRemaining;

    bool hasTimerStarted;
    float nextSecondEndTime;


    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player Character").GetComponent<FpsMovement>();
        hasTimerStarted = false;
        timeRemaining = 60;
    }


    // Update is called once per frame
    void Update() {
        // once player moves or looks around and timer hasn't started yet, start timer
        // without !hasTimerStarted, BeginCountdown would be called every time player moves after not moving
        if (!hasTimerStarted && player.getVelocity() > 0)
            BeginCountdown();
    }


    async void BeginCountdown() {
        hasTimerStarted = true;

        // wait until the task timerTick has finished before running timerTick again
        for (int i = 0; i < 60; i++) {
            await timerTick();
        }

        SceneManager.LoadScene("LossScene");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }


    async Task timerTick() {
        // task is not complete until 1 second has passed
        nextSecondEndTime = Time.time + 1;
        while (Time.time < nextSecondEndTime) {
            await Task.Yield();
        }

        // update timeRemaining and UI timer
        Debug.Log(timeRemaining);
        timeRemaining -= 1;
        gameObject.GetComponent<TextMeshProUGUI>().text = $"Time Remaining: {timeRemaining}";
    }
}

