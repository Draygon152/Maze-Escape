using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public class UICountdown : MonoBehaviour
{
    public int timeRemaining;

    float nextSecondEndTime;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            BeginCountdown();
        }
    }

    async void BeginCountdown()
    {
        for (int i = 0; i < 60; i++)
        {
            await timerTick();
        }
    }

    async Task timerTick()
    {
        nextSecondEndTime = Time.time + 1;
        while (Time.time < nextSecondEndTime)
        {
            await Task.Yield();
        }

        timeRemaining -= 1;
        gameObject.GetComponent<TextMeshProUGUI>().text = $"Time Remaining: {timeRemaining}";
    }
}
