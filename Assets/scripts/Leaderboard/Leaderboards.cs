
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;



public class Leaderboards : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        //"615be92fdb4758523184c13910622154968eb8c495a19d41d929d17729754fd0";
        "d1fd9df8fe7ebed5e5244a6695f0c694f607342bab3c4480562c48d273d91665";

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