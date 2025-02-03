using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TMP_Text scoreText; // 显示分数的 UI 文本

    void Start()
    {
        int savedScore = PlayerPrefs.GetInt("PlayerScore", 0); // 获取保存的分数
        scoreText.text = savedScore.ToString();
    }
}