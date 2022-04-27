using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static string totalScore;
    public static string topScore;

    [SerializeField] private Text topScoreText;
    [SerializeField] private Text totalScoreText;

    private int score = 0;

    void Start()
    {
        topScoreText.text = "Top Score: " + PlayerPrefs.GetInt("topScore", score).ToString();
    }

    private void Update()
    {
        if (totalScoreText != null)
            totalScoreText.text = totalScore;
    }
}
