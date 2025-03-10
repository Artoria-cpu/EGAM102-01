using UnityEngine;

public class Ding : MonoBehaviour
{
    public AudioClip dingclip;
    public AudioSource dingSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            dingSource.clip = dingclip;
            dingSource.Play();
        }

    }
}
