using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Health = 100; // Various stats
    public int DmgMult = 0;
    public int Stamina = 0;
    public int Defence = 0;

    int currentHealth;

    void Start()
    {
        currentHealth = Health;
    }

    public void TakingDmg(int Damage) // Player loses health
    {
        currentHealth -= Damage;

        if (currentHealth <= 0)
        {
            death();
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
