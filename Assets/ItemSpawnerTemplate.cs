using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class ItemSpawnerTemplate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject itemPrefab;
    public int spawnAmount = 15;

    public int currentItemCount = 0;
    public Vector3 spawnAreaSize = new Vector3(100, 1, 100);

    public float respawnDelay = 3f;

    void Start()
    {
        //currentItemCount = spawnAmount;
        StartCoroutine(SpawnInitialItems());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void spawnInitialItems() {
    //     for(int i = 0; i < spawnAmount; i++) {
    //         Vector3 randomPosition = new Vector3(
    //             Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
    //             Random.Range(0, spawnAreaSize.y), // Adjust for height variation if needed
    //             Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)

                
    //         );

    //         Instantiate(itemPrefab, randomPosition, Quaternion.identity);
        
    //     }
    // }

     IEnumerator SpawnInitialItems()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            SpawnItem();
            yield return new WaitForSeconds(0.1f); // Slight delay to prevent lag spikes
        }
    }

    void SpawnItem() {
         Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(0, spawnAreaSize.y), // Adjust for height variation if needed
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)

                
            );

            Instantiate(itemPrefab, randomPosition, Quaternion.identity);
            currentItemCount += 1;
            Debug.Log("current Items in game: " + currentItemCount);
    }

    public IEnumerator RespawnItemWithDelay()
    {
        yield return new WaitForSeconds(respawnDelay); // Wait before spawning
        SpawnItem();
    }

    public void ItemCollected()
    {
        currentItemCount--; // Reduce count when an item is picked up
        StartCoroutine(RespawnItemWithDelay()); // Trigger delayed respawn
    }

    
}
