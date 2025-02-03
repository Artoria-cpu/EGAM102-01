using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TMP_Text scoreText; // ��ʾ������ UI �ı�

    void Start()
    {
        int savedScore = PlayerPrefs.GetInt("PlayerScore", 0); // ��ȡ����ķ���
        scoreText.text = savedScore.ToString();
    }
}