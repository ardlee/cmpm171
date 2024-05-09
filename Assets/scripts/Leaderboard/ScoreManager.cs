
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputScore;
    [SerializeField] TMP_InputField inputName;
    //[SerializeField] private TextMeshProUGUI inputName;

    public UnityEvent<string, int> submitScoreEvent;
    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }
}

//using UnityEngine;
//using TMPro;
//using UnityEngine.Events;

//public class ScoreManager : MonoBehaviour
//{
//    public Timer timerScript; // Reference to the Timer script
//    public TextMeshProUGUI inputScore;
//    public TextMeshProUGUI inputName;

//    public UnityEvent<string, int> submitScoreEvent;

//    public void SubmitScore()
//    {
//        float timerValue = timerScript.TimerValue;
//        submitScoreEvent.Invoke(inputName.text, (int)timerValue);
//    }
//}
