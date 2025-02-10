using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameend : MonoBehaviour
{
   
    
        public string end; 
        public List<GameObject> enemies = new List<GameObject>(); 
        public GameObject player; 

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
                    SceneManager.LoadScene(end); 

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
