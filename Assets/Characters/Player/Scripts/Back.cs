using UnityEngine;

public class Back : MonoBehaviour
{
    public LayerMask enemyLayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enemy behind");
    }
}
