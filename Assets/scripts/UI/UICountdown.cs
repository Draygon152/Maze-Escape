using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.SceneManagement;

public class UICountdown : MonoBehaviour
{
    public int timeRemaining;
    public GameObject player;
    CharacterController playerCC;

    bool hasTimerStarted;
    float nextSecondEndTime;

    // Start is called before the first frame update
    void Start()
    {
        playerCC = player.GetComponent<CharacterController>();
        hasTimerStarted = false;
        timeRemaining = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // once player moves or looks around and timer hasn't started yet, start timer
        // without !hasTimerStarted, BeginCountdown would be called every time player moves after not moving
        if (playerCC.velocity.magnitude > 0 && !hasTimerStarted)
        {
            BeginCountdown();
        }
    }

    async void BeginCountdown()
    {
        hasTimerStarted = true;

        // wait until the task timerTick has finished before running timerTick again
        for (int i = 0; i < 60; i++)
        {
            await timerTick();
        }
        SceneManager.LoadScene("LossScene");
    }

    async Task timerTick()
    {
        // task is not complete until 1 second has passed
        nextSecondEndTime = Time.time + 1;
        while (Time.time < nextSecondEndTime)
        {
            await Task.Yield();
        }

        // update timeRemaining and UI timer
        Debug.Log(timeRemaining);
        timeRemaining -= 1;
        gameObject.GetComponent<TextMeshProUGUI>().text = $"Time Remaining: {timeRemaining}";
    }
}
