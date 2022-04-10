using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar; // Gets the slider
    public PlayerStats playerHealth; // Gets health from PlayerStats

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.Health; // Sets max value
        healthBar.value = playerHealth.Health;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
