using UnityEngine;
using System.Collections;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject characterPrefab; 
    public Transform path1Start; 
    public Transform path2Start; 
    public float minSpawnInterval = 1f; 
    public float maxSpawnInterval = 2f; 

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

            CharacterController2 characterScript = newCharacter.GetComponent<CharacterController2>();

            characterScript.StartMoving();
        }
    }

}

