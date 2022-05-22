using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
  
    public int[,] shopItems = new int [5,5];
    public float coins=100;
    public Text coinsTXT;
    public PowerupController powerupController;

    public void Update()
    {
        coinsTXT.text = "COINS "+ coins.ToString();
    }

    void Start()
    {
        coinsTXT.text = "Coins " + coins.ToString();

        //LA fila 1 SON ELS ID DELS ITEMS
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //PRICE, la fila 2 son els preus
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 25;
        shopItems[2, 3] = 40;
        shopItems[2, 4] = 100;
    }

   
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(coins>= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            //substract paid coins
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];

            //Update text coins
            coinsTXT.text = "Coins " + coins.ToString();

            if (ButtonRef.GetComponent<ButtonInfo>().itemID == 1)
            {
                powerupController.SpawnPowerup(powerupController.powerups[0], new Vector3(-75f, -11, 0));

            } 
            else if (ButtonRef.GetComponent<ButtonInfo>().itemID == 2)
            {
                powerupController.SpawnPowerup(powerupController.powerups[1], new Vector3(-75f, -11, 0));
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().itemID == 3)
            {
                powerupController.SpawnPowerup(powerupController.powerups[2], new Vector3(-75f, -11, 0));
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().itemID == 4)
            {
                powerupController.SpawnPowerup(powerupController.powerups[4], new Vector3(-75f, -11, 0));
            }



        }
    }
}
