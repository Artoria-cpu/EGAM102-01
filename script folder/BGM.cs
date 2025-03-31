using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM Instance;

    private AudioSource audioSource;

    public AudioClip dingclip;

    public AudioSource dingSource;

    void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

       
        Instance = this;
        DontDestroyOnLoad(gameObject); 

        dingSource.clip = dingclip;
        dingSource.Play();

    }
}
