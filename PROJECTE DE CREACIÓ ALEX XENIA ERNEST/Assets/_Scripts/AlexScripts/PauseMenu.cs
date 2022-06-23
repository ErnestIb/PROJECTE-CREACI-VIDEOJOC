using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void OnPause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }    

    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
