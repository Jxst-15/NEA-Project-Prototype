using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int Health = 350; // Health
   
    private int currentHealth;

    public GameObject hitBlink;

    void Start()
    {
        currentHealth = Health;
    }

    public void TakingDmg (int Damage) // Enemy takes damage
    {
        currentHealth -= Damage;
        Invoke("EHitBlink", 0f);
        Invoke("DHitBlink", 0.1f);

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

    private void death() // Enemy death
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 1f);
        Debug.Log("Enemy died");
    }
}
