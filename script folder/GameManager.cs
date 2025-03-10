using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class GameManager : MonoBehaviour
{
    public int left = 0;
    public TMP_Text leftText;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftText.text = left.ToString();
    }

    public void Loseleft()
    {
        left--;

    }
}
