using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator m_Animator;

    private bool m_IntroDone;
    private bool m_Settings;
    private bool m_Play;

    private enum MenuState
    {
        Intro,
        MainMenu, 
        Settings,
        Play
    }
    private MenuState m_CurrentState;
 
    // Start is called before the first frame update
    void Start()
    {
        m_IntroDone = false;
        m_Settings = false;
        m_Play = false;
    }

    private void Update() {
        m_Animator.SetBool("IntroDone", m_IntroDone);
    }

    public void EnterSettings() {ChangeState(MenuState.Settings);}
    public void ExitSettings() {ChangeState(MenuState.MainMenu);}
    public void EnterPlay() {ChangeState(MenuState.Play); SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);}
    public void EnterMenu() {ChangeState(MenuState.MainMenu);}


    private void ChangeState(MenuState _newState)
        {
            OnLeaveState(m_CurrentState);
            OnEnterState(_newState);

            m_CurrentState = _newState;
        }

    private void OnLeaveState(MenuState _previousState)
        {
            switch (_previousState)
            {
                case MenuState.Intro:
                m_IntroDone = false;
                
                    break;
                case MenuState.MainMenu:
                    break;
                case MenuState.Settings:
                m_Animator.SetBool("Settings", false);

                m_Settings = false;
                    break;
            }
        }

    private void OnEnterState(MenuState _nextState)
        {
            switch(_nextState)
            {
                case MenuState.Intro:
                    break;
                case MenuState.MainMenu:
                m_IntroDone = true;
                    break;
                case MenuState.Settings:
                m_Animator.SetBool("Settings", true);
                m_Settings = true;
                    break;
            }
        }



}
