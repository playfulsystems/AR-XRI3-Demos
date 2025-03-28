using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; 
    public float distFromCenter = 5f; 
    public float spawnRate = 3f; 
    float nextSpawnCountdown; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextSpawnCountdown = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawnCountdown < 0)
        { 

            // find spawn position
            Vector2 randomPositionOnCircle =   Random.insideUnitCircle.normalized * distFromCenter; 
            Vector3 spawnPosition =  new Vector3(randomPositionOnCircle.x, transform.position.y, randomPositionOnCircle.y); 

            // create enemy
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity); 

            nextSpawnCountdown = spawnRate; 

        }
        
        // update timer
        nextSpawnCountdown -= Time.deltaTime; 
    }
}
