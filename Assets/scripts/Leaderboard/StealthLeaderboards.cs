
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;



public class StealthLeaderboards : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        //"615be92fdb4758523184c13910622154968eb8c495a19d41d929d17729754fd0";
        "4c7d92e2078531198c80ae6977f974ed7d1bc014d9839fb8f2b4cf2b9707860f";

    private void Start()
    {
        GetLeaderboard();
    }
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));

    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
        {
            GetLeaderboard();
        }));
    }
}