using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class key : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player; 
    public List<GameObject> enemies = new List<GameObject>(); 
    public GameObject obs; 
    public TMP_Text alock; 
    public TMP_Text unlock; 

    private void Start()
    {
        alock.gameObject.SetActive(true);
        unlock.gameObject.SetActive(false);
    }
    void Update()
    {
        CheckCollisions();
        
    }

    void CheckCollisions()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null && IsColliding(enemy, player))
            {
                Destroy(obs); //able to pass
                alock.gameObject.SetActive(false); 
                unlock.gameObject.SetActive(true); 
            }
        }
    }

    bool IsColliding(GameObject obj1, GameObject obj2)
    {
        if (obj1 == null || obj2 == null) return false;

        Collider2D col1 = obj1.GetComponent<Collider2D>();
        Collider2D col2 = obj2.GetComponent<Collider2D>();

        return col1 != null && col2 != null && col1.bounds.Intersects(col2.bounds);
    }
}
