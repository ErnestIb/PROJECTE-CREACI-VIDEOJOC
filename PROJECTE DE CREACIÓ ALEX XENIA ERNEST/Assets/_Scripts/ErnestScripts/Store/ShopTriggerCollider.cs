using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    [SerializeField]
    private UIShop uiShop;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AudioManager.PlaySound("ShowShop", GetComponent<AudioSource>());
            uiShop.Show();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AudioManager.PlaySound("HideShop", GetComponent<AudioSource>());
            uiShop.Hide();
        }
    }
}
