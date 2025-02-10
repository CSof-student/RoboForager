using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject shopUI;
    void Start()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleShop()
    {
        shopUI.SetActive(!shopUI.activeSelf); 
         Debug.Log("Toggling Shop. Current state: " + shopUI.activeSelf);
    }
}
