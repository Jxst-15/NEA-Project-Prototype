using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region variables
    public int Health = 450; // Various stats
    private int currentHealth;
    public static bool dead = false;
    
    public static int LDamage = 30; // Light attack damage num
    public static int HDamage = 50; // Heavy attack damage num

    public HealthBar healthBar;
    public GameObject deathScreen; // Death screen
    #endregion

    void Start()
    {
        deathScreen.SetActive(false);
        currentHealth = Health;
    }

    public void TakingDmg(int Damage) // Player loses health
    {
        if (gameObject.GetComponent<PlayerCombat>().blocking == false) // If player not blocking then enemy attacks damage player else no damage taken
        {
            currentHealth -= Damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0) // If health reaches 0 then player is defeated
            {
                healthBar.SetHealth(0);
                death();
            }
        }
    }

    //public void TakingDmgBack(int Damage) // Method for player losing health if attacked from behind
    //{
    //    currentHealth -= Damage;
    //    healthBar.SetHealth(currentHealth);

    //    if (currentHealth <= 0)
    //    {
    //        healthBar.SetHealth(0);
    //        death();
    //    }
    //}

    private void death() // Player death, player is disabled and can no longer play game
    {
        dead = true;
        deathScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Debug.Log("Player dead");
    }
}
