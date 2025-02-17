using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour
{
    public GameObject player; 
    public GameObject[] enemys; 
    public float spawnradius = 5f; 
    public float minspawntime = 2f;
    public float maxspawntime = 5f; 
    public int minenemy = 1; 
    public int maxenemy = 5; 

    void Start()
    {
        StartCoroutine(SpawnenemiesLoop()); 
    }

    IEnumerator SpawnenemiesLoop()
    {
        while (true)
        {
            float wait = Random.Range(minspawntime, maxspawntime); 
            yield return new WaitForSeconds(wait); 

            Spawnenemies(); 
        }
    }

    void Spawnenemies()
    {
        

        int enemycount = Random.Range(minenemy, maxenemy + 1); //random count

        for (int i = 0; i < enemycount; i++)
        {
            Vector2 spawnposition = Getrandomspawnposition(); //random position
            GameObject enemypre = enemys[Random.Range(0, enemys.Length)]; //randomtype
            Instantiate(enemypre, spawnposition, Quaternion.identity); //spawn
        }
    }

    // 计算随机生成位置（以玩家为中心的圆周内）
    Vector2 Getrandomspawnposition()
    {
        Vector2 randomoffset = Random.insideUnitCircle.normalized * Random.Range(1f, spawnradius);
        return (Vector2)player.transform.position + randomoffset;
    }
}