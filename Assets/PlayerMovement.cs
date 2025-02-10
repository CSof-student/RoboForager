using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CharacterController controller;
    private float speed = 5f;
    private float gravity = -15f;
    private float jumpHeight = 1f;

    //public float test;
     private Vector3 velocity;
    private bool isGrounded;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //staying on the ground bug fix stuff
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

         // Get Input from WASD keys
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Move in the direction relative to the camera
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // jumbing
        if (isGrounded && Input.GetButtonDown("Jump")) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); 
        }
        // Apply Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        //this will be rotate w/ mouse
        transform.Rotate(0,Input.GetAxis("Mouse X")*speed,0);
    }
}

