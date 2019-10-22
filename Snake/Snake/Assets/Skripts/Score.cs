using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreNowText;
    public TextMeshProUGUI BestNowText;
    int scoreNow;
    void LateUpdate()
    {

        scoreNow = FindObjectOfType<Snake>().score;
        ScoreNowText.text = scoreNow.ToString();
        if (PlayerPrefs.GetInt("BestClassic") < scoreNow)
        {
            PlayerPrefs.SetInt("BestClassic", scoreNow);

        }
        BestNowText.text = PlayerPrefs.GetInt("BestClassic").ToString();



    }
    public void TopScore()
    {
        if (!PlayerPrefs.GetString("Top10").Any())
        {
            PlayerPrefs.SetString("Top10", "0,0,0,0,0,0,0,0,0,0");
        }
        List<int> top = PlayerPrefs.GetString("Top10").Split(',').Select(int.Parse).ToList();
        for (int i = 0; i < top.Count; i++)
        {
            if (top.Contains(scoreNow))
            {
                return;
            }
            if (scoreNow > top[i])
            {
                top.Insert(i, scoreNow);
                if (top[top.Count - 1] != scoreNow)
                {
                    top.RemoveAt(top.Count - 1);
                }

                break;
            }
        }
        PlayerPrefs.SetString("Top10", string.Join(",", top));

    }
}
