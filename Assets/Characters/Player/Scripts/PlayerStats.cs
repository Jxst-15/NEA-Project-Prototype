using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Health = 450; // Various stats
    public static int LDamage = 30; // Light attack damage num
    public static int HDamage = 50; // Heavy attack damage num
    public int Stamina = 0;
    public int Defence = 0;

    int currentHealth;

    void Start()
    {
        currentHealth = Health;
    }

    public void TakingDmg(int Damage) // Player loses health
    {
        if (PlayerCombat.blocking == false)
        {
            currentHealth -= Damage;

            if (currentHealth <= 0)
            {
                death();
            }
        }
    }

    private void death() // Player death, player is disabled and can no longer play game
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Debug.Log("Player dead");
    }
}
