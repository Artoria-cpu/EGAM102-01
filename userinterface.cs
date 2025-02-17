using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class userinterface : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scores;
    public float countdownTime = 10f;
    public string end;
    public string win;
    public TMP_Text timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        scores.text = score.ToString();
        timerText.text = Mathf.CeilToInt(countdownTime).ToString();


    }
    public void AddScore(int number)
    {
        score += number;

    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;

            yield return null;
        }

        countdownTime = 0;

        
       
        
            if (score > 120) 
            {
                SceneManager.LoadScene(win);
            }
            else
            {
                SceneManager.LoadScene(end);
            }
        
            
    }

}
