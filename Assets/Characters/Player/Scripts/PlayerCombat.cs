using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public Transform blockPoint;
    public LayerMask enemyLayers;

    public int LDamage = 10; // Light attack damage num
    public int HDamage = 20; // Heavy attack damage num
    
    public float attackRange = 0f; // How far character can hit
    public float attackSpeed = 2f; // How fast character can attack (Attack rate)
    float nextAttack = 0f; // When player can next attack

    public float blockRange = 0f;

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
            Debug.Log("Blocking");
            Block();
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
                enemy.GetComponent<EnemyStats>().TakingDmg(LDamage);
                Debug.Log("Enemy hit (Light)");
            }
        }
        else if (Input.GetKeyDown(KeyCode.K) == true)
        {
            foreach (Collider2D enemy in enemiesHit)
            {
                enemy.GetComponent<EnemyStats>().TakingDmg(HDamage);
                Debug.Log("Enemy hit (Heavy)");
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

    void OnDrawGizmosSelected() // Helps with determining attacking range
    {
        if (attackPoint == null) // If no attack point/ not attacking, then no attack point given
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange); // Draws attack range
    }
}
