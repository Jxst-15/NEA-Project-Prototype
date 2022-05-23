using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    #region variables
    public int Health = 350; // Health
    private int currentHealth;

    public GameObject hitBlink; // For enemy blinking white when damage taken
    #endregion

    void Start()
    {
        currentHealth = Health;
    }

    public void TakingDmg (int Damage) // Enemy takes damage
    {
        currentHealth -= Damage;
        Invoke("EHitBlink", 0f); // Activates white blink
        Invoke("DHitBlink", 0.1f); // Deactivates white blink after 0.1 seconds

        if(currentHealth <= 0)
        {
            death();
        }
    }

    private void EHitBlink() 
    {
        hitBlink.SetActive(true);
    }
    private void DHitBlink()
    {
        hitBlink.SetActive(false);
    }

    private void death() // Enemy death, enemy object is destroyed 
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
        Debug.Log("Enemy died");
    }
}
