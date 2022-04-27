using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public LayerMask enemyLayers;
    private bool enemyBehind = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //var TriggerList : List.< Collider > = new List.< Collider > ();
        enemyBehind = true;
        Debug.Log("Enemy behind");
    }
}
