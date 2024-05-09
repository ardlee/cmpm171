
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using System.Security.Cryptography.X509Certificates;

public class Leaderboards : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        "6eb66ecbcdf8f5e1daa6957035da76d1b6e504c5f8052ec9ff280e6dc0bdd12a";

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
