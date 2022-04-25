using UnityEngine;

public class Pausing : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // If ESC key pressed
        {
            paused = !paused;
            if (paused == false && !PlayerStats.dead) // Only if player is not dead else, player no longer able to move
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().enabled = true;
            }
        }

        if (paused == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false; // Both disable player attack + movement
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().enabled = false;
            pauseMenu.SetActive(true); 
            Time.timeScale = 0f; // Pauses game
        }
        else
        {
            pauseMenu.SetActive(false); // Disables pause menu UI
        }
    }
}
