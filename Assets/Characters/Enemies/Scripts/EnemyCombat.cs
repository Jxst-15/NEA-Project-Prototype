using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Transform attackPoint;
    private GameObject target;

    public int LDamage = 10; 
    public int HDamage = 20; 

    public float attackRange = 0f; 
    public float attackSpeed = 2f; 
    float nextAttack = 0f; 
       
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }
}
