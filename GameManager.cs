using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int lives = 0;
    public TMP_Text scoreText;
    
    
    public string end = "end";
    public GameObject miss; 
    public Animator animator;

    void Start()
    {
        
     miss.SetActive(false); 
        

        
     animator = miss.GetComponent<Animator>();
            
        
    }
    private void Awake()
    {
        Instance = this;
        
    }

    public void AddScore()
    {
        score++;
       
    }

    public void LoseLife()
    {
        lives++;
        UpdateLives(lives);

        if (lives >= 3)
        {
            SceneManager.LoadScene(end);
        }
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }
    public void UpdateLives(int newLives)
    {
        lives = newLives;
        StartCoroutine(HandleGameStatus());
    }
    IEnumerator HandleGameStatus()
    {
        if (miss == null || animator == null)
        {
            
            yield break;
        }

       
        if (lives == 1)
        {
            miss.SetActive(true);
        }
        
        else if (lives == 2)
        {
            animator.SetTrigger("to2");
        }
        
        else if (lives == 3)
        {
            animator.SetTrigger("to3");
        }

        

        Time.timeScale = 0f; 
        yield return new WaitForSecondsRealtime(1f); 
        Time.timeScale = 1f; 
    }
}