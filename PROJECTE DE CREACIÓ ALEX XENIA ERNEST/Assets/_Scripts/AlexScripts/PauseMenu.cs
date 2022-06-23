using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject  m_MenuHUD;
    void Start()
    {
        m_MenuHUD.SetActive(false);
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        m_MenuHUD.SetActive(true);
    }    

    public void Resume()
    {
        Time.timeScale = 1;
        m_MenuHUD.SetActive(false);
    }
}
