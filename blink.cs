using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class blink : MonoBehaviour
{
    public GameObject laser; 
    public float duration = 0.5f; 
    private Coroutine coroutine; 

    public AudioSource lasersource;

    public AudioClip laserclip;

    void Start()
    {
        laser.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Startflashing();
            lasersource.clip = laserclip;
            lasersource.Play();
        }

        if (Input.GetMouseButtonUp(0)) //left
        {
            Stop();
        }
    }

    void Startflashing()
    {
        if (coroutine == null) 
        {
            coroutine = StartCoroutine(FlashGameObject());
        }
    }

    void Stop()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
       laser.SetActive(false);
    }

    IEnumerator FlashGameObject()
    {
        laser.SetActive(true); 
        while (true)
        {
            laser.SetActive(!laser.activeSelf); 
            yield return new WaitForSeconds(duration); //wait
        }
    }
}