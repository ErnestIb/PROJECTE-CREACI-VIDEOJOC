using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndMenu : MonoBehaviour
{
    [SerializeField] Animator m_Animator;

    private bool m_Done = false;
    void Start()
    {
    }
        
    private void Update() {m_Animator.SetBool("IntroDone", m_Done);}

        
    public void EnterPlay() {SceneManager.LoadScene(1);}

    public void Exit() {Application.Quit();}


    public void EnterMenu()
    {
        m_Done = true;
    }

    
}
