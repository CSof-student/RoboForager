using System;
using Unity.VisualScripting;
using UnityEngine;

public class ItemTemplate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //GameObject itemPrefab;
    Inventory inventory; 
    public String itemName;
    //Player player;
    ItemSpawnerTemplate itemSpawner;

    public int itemMultiplyer = 1;
    public void Start()
    {
        inventory = FindObjectsByType<Inventory>(FindObjectsSortMode.None)[0];
        itemSpawner = FindObjectsByType<ItemSpawnerTemplate>(FindObjectsSortMode.None)[0];
        setItemName("Item1"); // temp
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player"))
        {

            // Add the item to inventory (placeholder function)
            Debug.Log("made contact with: "+ itemName);
            Debug.Log("Item capacity: " + inventory.getItemCapacity(itemName));
            if (inventory.getItemCapacity(itemName) >= inventory.getItemNumber(itemName) + 1*itemMultiplyer) {

            
                Debug.Log("Picked up: " + itemName);
                inventory.addItem(itemName, 1); // add multiplyer later potentially
                Debug.Log("Inventory now contains: " + inventory.getItemNumber(itemName));
                itemSpawner.ItemCollected(gameObject);

                // Destroy the item after pickup
                // 
                gameObject.SetActive(false);
            }
        }
    }
    public void setItemName(string name) {
        itemName = name;
    }
}
