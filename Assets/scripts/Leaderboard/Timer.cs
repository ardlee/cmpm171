using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime = 0f;
    public float TimerValue { get; private set; }

    private void Start()
    {
        TimerValue = startTime;
    }

    private void Update()
    {
        TimerValue += Time.deltaTime;

        // Format the timer value into minutes, seconds, and milliseconds
        string minutes = Mathf.Floor(TimerValue / 60).ToString("00");
        string seconds = Mathf.Floor(TimerValue % 60).ToString("00");
        string milliseconds = Mathf.Floor((TimerValue * 1000) % 1000).ToString("000");

        // Update the UI text to display the timer
        timerText.text = $"{minutes}:{seconds}:{milliseconds}";
    }
}
