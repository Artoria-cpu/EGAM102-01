using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class userinterface : MonoBehaviour
{
    public int score;
    public TMP_Text scores;
    public int health;
    public TMP_Text healthshow;
    public string why = "why";
    public string lose = "lose";
    public int sudden;
    public int enhealth;
    public TMP_Text showsudden;
    public TMP_Text enemyhealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scores.text = score.ToString();
        healthshow.text = health.ToString();
        enemyhealth.text = enhealth.ToString();

        if (health <= 0)
        {
            int currentScore = score; // 假设当前分数
            PlayerPrefs.SetInt("PlayerScore", currentScore); // 保存分数
            PlayerPrefs.Save();
            SceneManager.LoadScene(lose);

        }

        if (enhealth <= 0)
        {
            int currentScore = score; // 假设当前分数
            PlayerPrefs.SetInt("PlayerScore", currentScore); // 保存分数
            PlayerPrefs.Save();
            SceneManager.LoadScene(why);
        }

    }

    public void AddScore(int number)
    {
        score += number;

    }

    public void Killhelath(int number)
    {
        health -= number;

    }

    public void eyk(int number)
    {
        enhealth -= number;

    }

    public void Plushelath(int number)
    {
        health += number;

    }


}
