using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private float enemyPosX, enemyPosY;

    public float speed;
    public Transform target; // Holds the target player to chase
    public LayerMask Player;
    public float minDistance;

    public Transform attackPointE;
    public int Dmg = 5;
    public float attackRangeE = 0f;
    public float attackSpeedE = 2f;
    float nextAttackE = 0f;
    
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>(); 
        enemyPosX = transform.localScale.x;
        enemyPosY = transform.localScale.y;
        if (_renderer == null)
        {
            Debug.Log("Enemy Sprite missing");
        }
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > minDistance) // Sees how far player is
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Moves enemy character towards the player 
        }
        else
        {
            if (Time.time >= nextAttackE) // Prevents spam attacks
            {
                EnemyAttack();
                nextAttackE = Time.time + 1f / attackSpeedE;
            }
        }
    }

    void EnemyAttack() // Attack method
    {
        Collider2D[] playerHit = Physics2D.OverlapCircleAll(attackPointE.position, attackRangeE, Player);

        foreach (Collider2D player in playerHit)
        {
            target.GetComponent<PlayerStats>().TakingDmg(Dmg);
            Debug.Log("Player hit");

        }
    }

    void OnDrawGizmosSelected() // Helps with determining attacking range
    {
        if (attackPointE == null) // If no attack point/ not attacking, then no attack point given
            return;

        Gizmos.DrawWireSphere(attackPointE.position, attackRangeE); // Draws attack range
    }
}
