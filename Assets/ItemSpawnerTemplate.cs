using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class ItemSpawnerTemplate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject itemPrefab;
    public GameObject ScrapMetalPrefab;
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
            SpawnItem(itemPrefab);
            SpawnItem(ScrapMetalPrefab);
            yield return new WaitForSeconds(0.1f); // Slight delay to prevent lag spikes
        }
    }

    void SpawnItem(GameObject item) {
        // if (itemPrefab == null) {
        //     Debug.LogError("ItemSpawnerTemplate: itemPrefab is null! Assign a prefab in the Inspector.");
        // return; // Prevents further execution if itemPrefab is missing
        //}
         Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(0, spawnAreaSize.y), // Adjust for height variation if needed
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)

                
            );

            Instantiate(item, randomPosition, Quaternion.identity);
            
            currentItemCount += 1;
            //Debug.Log("current Items in game: " + currentItemCount);
    }

    public IEnumerator RespawnItemWithDelay(GameObject old)
    {
        yield return new WaitForSeconds(respawnDelay); // Wait before spawning
        Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(0, spawnAreaSize.y), // Adjust for height variation if needed
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)

                
            );
        old.transform.position = randomPosition; // Move item to a new position
        old.SetActive(true); // Reactivate the old item
        //SpawnItem();
        //Destroy(old);
    }

    public void ItemCollected(GameObject oldItem)
    {
        currentItemCount--; // Reduce count when an item is picked up
        StartCoroutine(RespawnItemWithDelay(oldItem)); // Trigger delayed respawn
    }

    
}
