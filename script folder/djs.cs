using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class djs : MonoBehaviour
{
    public float countdownTime = 120f;
    public string End;
    public TMP_Text timerText;

    void Start()
    {
        StartCoroutine(Countdown());

    }

    private void Update()
    {
        timerText.text = Mathf.CeilToInt(countdownTime).ToString();
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0
)
        {
            countdownTime -= Time.deltaTime;

            yield return null;
        }

        
        SceneManager.LoadScene(End);
    }
}