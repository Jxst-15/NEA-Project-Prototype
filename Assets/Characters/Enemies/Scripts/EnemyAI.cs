using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private float enemyScaleX, enemyScaleY;

    public float Espeed; // Enemy movement speed
    public Transform target; // Holds the target player to chase
    public LayerMask Player; // Targeting player layer
    public float minDistance; // Minimum distance that enemy can be from player

    public Transform attackPointE;
    public int LDamage = 5;
    public int HDamage = 10;
    public float attackRangeE = 0f;
    public float attackSpeedE = 2f;
    float nextAttackE = 0f;
    public static bool attacking = false;
    
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>(); 
        enemyScaleX = transform.localScale.x;
        enemyScaleY = transform.localScale.y;
        if (_renderer == null)
        {
            Debug.Log("Enemy Sprite missing");
        }
        Physics2D.IgnoreLayerCollision(8, 7, true);
        Physics2D.IgnoreLayerCollision(8, 8, true);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // Finds the player and assigns it to target   
    }

    void Update()
    {   
        if (Vector2.Distance(transform.position, target.position) > minDistance) // Sees how far player is (if player is not in range)
        {
            attacking = false;
            Vector2 xTarget = new Vector2(target.position.x, transform.position.y); // Makes sure enemy only chases on the X axis
            transform.position = Vector2.MoveTowards(transform.position, xTarget, Espeed * Time.deltaTime); // Moves enemy character towards the player 
        }
        else // if distance less than or equal to minDistance
        {
            if (Time.time >= nextAttackE) // Prevents spam attacks
            {
                EnemyAttack();
                nextAttackE = Time.time + 1f / attackSpeedE;
            }
        }

        if (transform.position.x < target.position.x) // The following flips the enemy sprite so it can attack/ follow the right way
        {
            _renderer.flipX = true;
            gameObject.transform.localScale = new Vector2(-enemyScaleX, -enemyScaleY);
        }
        else if (transform.position.x > target.position.x)
        {
            _renderer.flipX = false;
            gameObject.transform.localScale = new Vector2(enemyScaleX, enemyScaleY);
        }
    }

    void EnemyAttack() // Attack method
    {
        attacking = true;
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(attackPointE.position, attackRangeE, Player);
        
        int dmgRoll = Random.Range(1, 6); // Decides if enemy attack is heavy or not

        if (dmgRoll == 1 || dmgRoll == 2 || dmgRoll == 3) // Light attacks
        {
            foreach (Collider2D player in playerHit)
            {
                target.GetComponent<PlayerStats>().TakingDmg(LDamage);
                Debug.Log("Player hit (Light)");
            }
        }
        else // Heavy attacks
        {
            foreach (Collider2D player in playerHit)
            {
                target.GetComponent<PlayerStats>().TakingDmg(HDamage);
                Debug.Log("Player hit (Heavy)");
            }
        }
    }

    void OnDrawGizmosSelected() // Helps with determining attacking range
    {
        if (attackPointE == null) // If no attack point/ not attacking, then no attack point given
            return;

        Gizmos.DrawWireSphere(attackPointE.position, attackRangeE); // Draws attack range
    }
}
