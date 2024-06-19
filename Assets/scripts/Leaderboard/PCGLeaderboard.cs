
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;



public class PCGLeaderboard: MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        //"615be92fdb4758523184c13910622154968eb8c495a19d41d929d17729754fd0";
        "7a73b3e95969597f80061f47287edec9ff0583138fa906d9c3f7049f096a7b5c";

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