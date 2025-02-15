using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    Dictionary<String, int> Storage = new Dictionary<String, int>();
    Dictionary<String, int> ItemCapacities = new Dictionary<string, int>();
    public TextMeshProUGUI item1Text; 
    public TextMeshProUGUI ScrapMetalText; 
    //IG add more of these as more items exist
    
    void Start()
    {
        //add all the itemcapacities
        ItemCapacities.Add("Item1", 25);
        ItemCapacities.Add("ScrapMetal",25);
        //add all the items to the dictionary at 0 stored
        Storage.Add("Item1", 0);
        Storage.Add("ScrapMetal", 0);
    }

    // Update is called once per frame
    void Update()
    {
        updateUI();
    }

    public void subtractItem(String itemName, int number) {
        Storage[itemName] = Storage[itemName] - number;
    }

    public void addItem(String itemName, int number) {
        // Debug.Log(itemName);
        // Debug.Log (Storage["Item1"]);
        if(ItemCapacities[itemName]< Storage[itemName] + number) {
            Storage[itemName] = ItemCapacities[itemName];
        }
        else{
            Storage[itemName] = Storage[itemName] + number;
        }
        
    }

    public int getItemNumber(String itemName) {
        return Storage[itemName];
    }

    private void updateUI(){
        //item1 is a placeholder for now
        item1Text.text = "Storage "+ getItemNumber("Item1").ToString()+ "/" + ItemCapacities["Item1"];
        ScrapMetalText.text = "Storage "+ getItemNumber("ScrapMetal").ToString()+ "/" + ItemCapacities["ScrapMetal"];
    }

    public int getItemCapacity(String itemName) {
        return ItemCapacities[itemName];
    }
}
