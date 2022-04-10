using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f; // Values for speed and jump
    public float jumpForce = 1f; 
    public bool onGround = false; // For GroundChecking 
    
    private SpriteRenderer _renderer;
    private float playerPosX, playerPosY;
    private Rigidbody2D rb;

    float doubleTapTime;
    KeyCode lastKey;

    public float dashSpeed;
    private float dashCount;
    public float startDashCount;
    private int side;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>(); // Grabs the sprite
        playerPosX = transform.localScale.x; // Values for transforming object on X axis
        playerPosY = transform.localScale.y;
        rb = GetComponent<Rigidbody2D>(); // Gets the rigid body component for dash mechanic
        if (_renderer == null)
        {
            Debug.Log("Player Sprite missing");
        }
        Physics2D.IgnoreLayerCollision(7, 8, true); // Player can walk through enemies 
        dashCount = startDashCount;
    }

    void Update()
    {
        Jump(); // Runs jump method
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // Creates Vector3 object 
        transform.position += movement * Time.deltaTime * movementSpeed; // Actual movement in game

        if (Input.GetAxisRaw("Horizontal") > 0) // If statements are for flipping the object on the X axis
        {
            _renderer.flipX = false;
            gameObject.transform.localScale = new Vector2(playerPosX, playerPosY);
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (doubleTapTime > Time.time && lastKey == KeyCode.D)
                {
                    side = 2;
                }
                else
                {
                    doubleTapTime = Time.time + 0.3f;
                }
                lastKey = KeyCode.D;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) // Player moving left
        {
            _renderer.flipX = true;
            gameObject.transform.localScale = new Vector2(-playerPosX, playerPosY);
            if (Input.GetKeyDown(KeyCode.A)) 
            {
                if (doubleTapTime > Time.time && lastKey == KeyCode.A) // Checks to see if D is double tapped and sees if the double tap time is more than time elapsed
                {
                    side = 1;
                }
                else
                {
                    doubleTapTime = Time.time + 0.3f; // If not then doubleTapTime is equal to time elapsed + the time to double tap
                }
                lastKey = KeyCode.A; // last key pressed is set to A
            }
        }
        dash(); // Runs dash method
    }

    void Jump()
    {
        if (Input.GetButtonDown("Vertical") && onGround == true) // Checks first if player on ground before allowing jump
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Moves player off the ground
        }
    }

    void dash()
    {
        if (side != 0) // Checks to see if player is moving first
        {
            if (dashCount <= 0) // So player will not dash infinitely
            {
                side = 0;
                dashCount = startDashCount;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashCount -= Time.deltaTime; // Constant speed 
                if (side == 1) 
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (side == 2) // If player is moving right
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }

}
