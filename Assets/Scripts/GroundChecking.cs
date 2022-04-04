using UnityEngine;

public class GroundChecking : MonoBehaviour
{
    GameObject TempChar; // Brings the player into GroundChecking

    void Start()
    {
        TempChar = gameObject.transform.parent.gameObject; // Defines the player
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") // Checks if player is on ground
        {
            TempChar.GetComponent<PlayerController>().onGround = true; // Set onGround to true so allows for jump
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // Checks if player in air
    {
        if (collision.collider.tag == "Ground")
        {
            TempChar.GetComponent<PlayerController>().onGround = false; // Player can no longer jump in air
        }
    }
}