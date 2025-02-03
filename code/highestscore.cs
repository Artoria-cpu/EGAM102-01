using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class highestscore : MonoBehaviour

{
    private int currentScore = 0;
    private int highScore = 0;
    public TMP_Text showc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int savedscore = PlayerPrefs.GetInt("PlayerScore", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        currentScore = savedscore;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        showc.text = highScore.ToString();
    }
}