using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int Health = 100; // Health
   
    int currentHealth;

    void Start()
    {
        currentHealth = Health;
    }

    public void TakingDmg (int Damage) // Enemy takes damage
    {
        currentHealth -= Damage;

        if(currentHealth <= 0)
        {
            death();
        }
    }

    private void death() // Enemy death
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;
        Debug.Log("Dead");
    }
}
