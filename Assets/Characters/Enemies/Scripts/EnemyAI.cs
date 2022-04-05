using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    private Transform target; // Holds the target player to chase
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // Moves enemy character towards the player       
        }
    }
}
