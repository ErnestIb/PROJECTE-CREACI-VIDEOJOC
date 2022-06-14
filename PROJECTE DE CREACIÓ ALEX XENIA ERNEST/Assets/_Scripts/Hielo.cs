using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hielo : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerMovement.isInHielo = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerMovement.isInHielo = false;
    }

}
