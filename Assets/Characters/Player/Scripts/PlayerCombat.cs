using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public Transform blockPoint;
    public LayerMask enemyLayers;

    //public int LDamage = 30; // Light attack damage num
    //public int HDamage = 50; // Heavy attack damage num
    //public float DmgMult = 1f;
    
    public float attackRange = 0f; // How far character can hit
    public float attackSpeed = 2f; // How fast character can attack (Attack rate)
    float nextAttack = 0f; // When player can next attack

    public float blockRange = 0f;

    string style = "Style 1";

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttack) // Prevents spamming of attacks
        {
            if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
            {
                Attack();
                //nextAttack = Time.time + 1f / attackSpeed;
            }
        }

        if (Input.GetKey(KeyCode.H)) // Blocking feature
        {
            Block();
            Debug.Log("Blocking");
        }
        
        if (Input.GetKey(KeyCode.LeftShift)) // Switching style feature
        {
            Time.timeScale = 0.5f; // Slows down gameplay
            StyleSwitch();
        }
        else
        {
            Time.timeScale = 1f; // Sets gameplay back to normal speed
        }
    }

    void Attack() // Attack method
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); // Array to get how many enemies player hit
        
        // Following 'if' statements to determine damage type
        if (Input.GetKeyDown(KeyCode.J) == true)
        {
            foreach (Collider2D enemy in enemiesHit) // Goes through every enemy and deals damage
            {
                enemy.GetComponent<EnemyStats>().TakingDmg(PlayerStats.LDamage);
                Debug.Log("Enemy hit (Light)" + PlayerStats.LDamage);
            }
        }
        else if (Input.GetKeyDown(KeyCode.K) == true)
        {
            foreach (Collider2D enemy in enemiesHit)
            {
                enemy.GetComponent<EnemyStats>().TakingDmg(PlayerStats.HDamage);
                Debug.Log("Enemy hit (Heavy)" + PlayerStats.HDamage);
            }
        }
        nextAttack = Time.time + 1f / attackSpeed; // Next attack time is given 
    }

    void Block() // Block method
    {
        Collider2D[] enemiesBlocked = Physics2D.OverlapCircleAll(blockPoint.position, blockRange, enemyLayers); // Get how many enemies player is blocking

        foreach (Collider2D enemy in enemiesBlocked)
        {
            Debug.Log("Attack Blocked");
        }
    }

    void StyleSwitch() // Switching combat styles (Currently only affects attack)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            style = "Style 1";
            //DmgMult = 1f;
            PlayerStats.LDamage = 30;
            PlayerStats.HDamage = 50;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            style = "Style 2";
            //DmgMult = 0.25f;
            PlayerStats.LDamage = 23;
            PlayerStats.HDamage = 38;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            style = "Style 3";
            //DmgMult = 0.40f;
            PlayerStats.LDamage = 42;
            PlayerStats.HDamage = 70;
        }
    }

    void OnDrawGizmosSelected() // Helps with determining attacking range
    {
        if (attackPoint == null) // If no attack point/ not attacking, then no attack point given
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange); // Draws attack range
    }
}
