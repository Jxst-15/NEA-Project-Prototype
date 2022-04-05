using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 1f; // Values for speed and jump
    public bool onGround = false; // For GroundChecking 
    
    private SpriteRenderer _renderer;
    private float playerPosX, playerPosY;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        playerPosX = transform.localScale.x;
        playerPosY = transform.localScale.y;
        if (_renderer == null)
        {
            Debug.Log("Player Sprite missing");
        }
    }

    void Update()
    {
        Jump(); // Runs jump function
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // Creates Vector3 object 
        transform.position += movement * Time.deltaTime * movementSpeed; // Actual movement in game
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _renderer.flipX = false;
            gameObject.transform.localScale = new Vector2(playerPosX, playerPosY);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _renderer.flipX = true;
            gameObject.transform.localScale = new Vector2(-playerPosX, playerPosY);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && onGround == true) // Checks first if player on ground before allowing jump
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
