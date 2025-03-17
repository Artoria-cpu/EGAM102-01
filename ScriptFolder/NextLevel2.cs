using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class NextLevel2 : MonoBehaviour
{
    public GameObject playerObject; 
    public List<GameObject> Activate; 
    public Animator timerAnimator; 
    public float holdTime = 1f; 
    public Image fadeImage; 
    public TextMeshProUGUI messageText; 
    public string nextSceneName; 
    public float fadeDuration = 2f; 
    public float textFadeDuration = 2f; 
    public GameObject Object;

    private bool isTransitioning = false;
    private bool readyForNextScene = false;
    private float timer = 0f;
    private bool isTouching = false;

    private SpriteRenderer visualRenderer;
    private Vector3 initialScale;

    private void Start()
    {
       
        foreach (GameObject obj in Activate)
        {
            if (obj.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
            }
        }

        
            fadeImage.gameObject.SetActive(false);
            Color color = fadeImage.color;
            fadeImage.color = new Color(color.r, color.g, color.b, 0);
        

        
            messageText.gameObject.SetActive(false);
            Color textColor = messageText.color;
            messageText.color = new Color(textColor.r, textColor.g, textColor.b, 0);
        

        
            timerAnimator.SetBool("isCounting", false); 
          
        

        
            Object.SetActive(false); 
            initialScale = Object.transform.localScale; 

            
            visualRenderer = Object.GetComponent<SpriteRenderer>();
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTransitioning && other.gameObject == playerObject)
        {
            isTouching = true;
            timer = 0f; 

            timerAnimator.SetBool("isCounting", true);
            timerAnimator.SetTrigger("NewTrigger");
            Object.SetActive(true);
            StartCoroutine(VisualEffectRoutine());
            

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!isTransitioning && other.gameObject == playerObject)
        {
            isTouching = false;
            timer = 0f; 

            
           
                timerAnimator.SetBool("isCounting", false);
            

            
                Object.SetActive(false);
                Object.transform.localScale = initialScale; 
                if (visualRenderer != null)
                {
                    Color color = visualRenderer.color;
                    color.a = 1f; 
                    visualRenderer.color = color;
                }
            

        }
    }

    private void Update()
    {
        if (isTouching && !isTransitioning)
        {
            timer += Time.deltaTime;

            if (timer >= holdTime)
            {
                StartCoroutine(StartTransition());
                isTransitioning = true;
            }
        }

        if (readyForNextScene && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(nextSceneName);
        }

    }

    private IEnumerator StartTransition()
    {
        
        
            timerAnimator.SetBool("isCounting", false);
        

       
        foreach (GameObject obj in Activate)
        {
            if (obj.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }

        
        fadeImage.gameObject.SetActive(true);
        float timer = 0f;
        Color color = fadeImage.color;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        
        messageText.gameObject.SetActive(true);
        timer = 0f;
        Color textColor = messageText.color;
        while (timer < textFadeDuration)
        {
            timer += Time.deltaTime;
            textColor.a = Mathf.Lerp(0, 1, timer / textFadeDuration);
            messageText.color = textColor;
            yield return null;
        }

        
        readyForNextScene = true;
    }

    private IEnumerator VisualEffectRoutine()
    {
        float effectTimer = 0f;
        while (isTouching && effectTimer < holdTime)
        {
            effectTimer += Time.deltaTime;

            
            float scaleMultiplier = Mathf.Lerp(1f, 2f, effectTimer / holdTime);
            Object.transform.localScale = initialScale * scaleMultiplier;

            
            Color color = visualRenderer.color;
            color.a = Mathf.Lerp(1f, 0f, effectTimer / holdTime);
            visualRenderer.color = color;
            

            yield return null;
        }
    }

    
}
