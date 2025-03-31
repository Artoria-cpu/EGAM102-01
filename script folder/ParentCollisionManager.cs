using UnityEngine;
using System.Collections.Generic;

public class ParentCollisionManager : MonoBehaviour
{
    public AudioClip collisionSound;
    private AudioSource audioSource;
    public AudioClip dingclip;
    public AudioSource dingSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        
        foreach (Transform child in transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            
            renderer.material.color = Color.gray * 0.5f; 
            

            if (!child.GetComponent<ChildCollisionReporter>())
            {
                var reporter = child.gameObject.AddComponent<ChildCollisionReporter>();
                reporter.manager = this;
            }
        }
    }

   
    public void OnChildCollision(GameObject a, GameObject b)
    {
       
        dingSource.clip = dingclip;
        dingSource.Play();
        

        SetWhite(a);
        SetWhite(b);
    }

    void SetWhite(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        
        renderer.material.color = Color.white;
        
    }
}




