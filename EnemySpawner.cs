using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject characterPrefab; 
    public Transform path1Start; 
    public Transform path2Start; 
    public float minSpawnInterval = 2f; 
    public float maxSpawnInterval = 5f; 
   

    void Start()
    {
        
        StartCoroutine(SpawnCharacterRoutine());
    }

    IEnumerator SpawnCharacterRoutine()
    {
        while (true)
        {
           
            
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);


            Transform spawnPoint = Random.Range(0, 2) == 0 ? path1Start : path2Start;

            GameObject newCharacter = Instantiate(characterPrefab, spawnPoint.position, Quaternion.identity);

            CharacterController characterScript = newCharacter.GetComponent<CharacterController>();

            characterScript.StartMoving(spawnPoint == path1Start);
        }
    }

}

