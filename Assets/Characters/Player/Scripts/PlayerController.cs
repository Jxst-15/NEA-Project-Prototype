using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f; // Values for speed and jump
    public float jumpForce = 1f; 
    public bool onGround = false; // For GroundChecking 
    
    private SpriteRenderer _renderer;
    private float playerPosX, playerPosY;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>(); // Grabs the sprite
        playerPosX = transform.localScale.x; // Values for transforming object on X axis
        playerPosY = transform.localScale.y;
        if (_renderer == null)
        {
            Debug.Log("Player Sprite missing");
        }
        Physics2D.IgnoreLayerCollision(7, 8, true);
    }

    void Update()
    {
        Jump(); // Runs jump function
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // Creates Vector3 object 
        transform.position += movement * Time.deltaTime * movementSpeed; // Actual movement in game
        
        if (Input.GetAxisRaw("Horizontal") > 0) // If statements are for flipping the object on the X axis
        {
            _renderer.flipX = false;
            gameObject.transform.localScale = new Vector2(playerPosX, playerPosY);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) // Player moving left
        {
            _renderer.flipX = true;
            gameObject.transform.localScale = new Vector2(-playerPosX, playerPosY);
        } 
    }

    void Jump()
    {
        if (Input.GetButtonDown("Vertical") && onGround == true) // Checks first if player on ground before allowing jump
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Moves player off the ground
        }
    }

}
