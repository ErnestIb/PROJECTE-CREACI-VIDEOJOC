using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Restart()
    {
        //1- Restart scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //2- Reset the player's position

        //Save the player's initial position when the game starts
    }
    
}
