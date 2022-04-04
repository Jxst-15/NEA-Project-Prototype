using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int Health = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Health;
    }

    public void TakingDmg (int dmg)
    {
        currentHealth -= dmg;

        if(currentHealth <= 0)
        {
            death();
        }
    }

    private void death()
    {
        Debug.Log("Dead");
    }
}
