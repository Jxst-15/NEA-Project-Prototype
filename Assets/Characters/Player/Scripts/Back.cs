using UnityEngine;

public class Back : MonoBehaviour
{
    public bool enemyBehind = false;

    Collider2D[] enemiesBehind = new Collider2D[4];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyBehind = true;
        Debug.Log("Enemy behind");
        //for (int i = 0; i < 4; i++)
        //{
        //    enemiesBehind[i] = collision;
        //}
        //foreach (Collider2D enemy in enemiesBehind)
        //{
        //    //gameObject.GetComponentInParent<PlayerStats>().TakingDmgBack(enemy.GetComponent<EnemyAI>().LDamage);
        //    Debug.Log("Player hit (Light) (Behind)");
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyBehind = false;
        //for (int i = 0; i < 4; i++)
        //{
        //    enemiesBehind[i] = null;
        //}
    }

}
