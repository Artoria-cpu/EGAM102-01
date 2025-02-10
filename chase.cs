using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class chase : MonoBehaviour
{
    public GameObject player; 
    public List<GameObject> enemies = new List<GameObject>(); 
    public collide collideScript; 
    public float sp = 2f; 

    void Update()
    {

       
    }

    public void MoveEnemiesTowardsPlayer()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null && player != null)
            {
                Vector3 direction = (player.transform.position - enemy.transform.position).normalized;
                enemy.transform.position += direction * sp * Time.deltaTime;
            }
        }
    }
}