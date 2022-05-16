using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver; // Game Over Screen
    public GameObject[] enemies; // All enemies in game

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Fills the array
        Debug.Log(enemies.Length);
    }

    void Update()
    {
        if (enemies.Length == 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            gameOver.SetActive(false);
        }
    }
}
