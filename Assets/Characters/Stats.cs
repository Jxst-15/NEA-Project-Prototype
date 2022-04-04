using UnityEngine;

public class Stats : MonoBehaviour
{
    public int Health = 100;
    public int DmgMult = 0;
    public int Stamina = 0;
    public int Defence = 0;
   
    int currentHealth;

    void Start()
    {
        currentHealth = Health;
    }

    public void TakingDmg (int Damage)
    {
        currentHealth -= Damage;

        if(currentHealth <= 0)
        {
            death();
        }
    }

    private void death()
    {
        Debug.Log("Dead");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
