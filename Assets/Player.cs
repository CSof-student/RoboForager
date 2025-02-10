using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int playerHealth = 100;
    public int healNum = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checkForDeath();
    }

    public void takeDamage(int damage) {
        playerHealth -= damage;
        Debug.Log("Damage take! Player health: " + playerHealth);
        checkForDeath();
    }

    void checkForDeath(){
        if (playerHealth <= 0) {
            Debug.Log("You should be dead :)");
            Application.Quit();
        }
    }
    void heal() {
        
    }
}
