using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEnemigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(transform.position.x > collision.transform.position.x)
            {
                collision.GetComponent<GhostEnemy>().push = -3;
            }
            else
            {
                collision.GetComponent<GhostEnemy>().push = 3;
            }
        }
    }
}
