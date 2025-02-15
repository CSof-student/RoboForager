using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public GameObject shopButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) {
            shopButton.SetActive(true);
        }
    }
}
