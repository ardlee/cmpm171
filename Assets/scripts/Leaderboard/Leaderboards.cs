
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

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
            // Convert the List to an array
            Dan.Models.Entry[] entries = msg.ToArray();

            // Sort the leaderboard data by score in ascending order
            entries = entries.OrderBy(entry => entry.Score).ToArray();

            int loopLength = (entries.Length < names.Count) ? entries.Length : names.Count;
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = entries[i].Username;
                scores[i].text = entries[i].Score.ToString();
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
