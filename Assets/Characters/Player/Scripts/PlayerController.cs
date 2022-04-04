using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 1f; // Values for speed and jump
    public bool onGround = false; // For GroundChecking 

    void Update()
    {
        Jump(); // Runs jump function
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // Creates Vector3 object 
        transform.position += movement * Time.deltaTime * movementSpeed; // Actual movement in game
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onGround == true) // Checks first if player on ground before allowing jump
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
