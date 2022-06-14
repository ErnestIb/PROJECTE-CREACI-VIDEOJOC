using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
    [SerializeField] string[] m_sentences;
    [SerializeField] TextMeshProUGUI m_TextDisplayed;
    [SerializeField] GameObject m_ContinueText;
    [SerializeField] GameObject m_Menu;

    public int cases = 1;
    private int index;
    public float m_TypingSpeed;
    private bool Happened;
    

    void Start()
    {
        StartCoroutine(TypeFirstSequence());
        m_ContinueText.SetActive(false);
        Happened = false;
    }

    IEnumerator TypeFirstSequence(){
        foreach(char letter in m_sentences[index].ToCharArray())
        {
            m_TextDisplayed.text += letter;
            yield return new WaitForSeconds(m_TypingSpeed);
        }
    }

    public void NextSentence(){
        
        if (index < m_sentences.Length-1)
        {
            index++;
            m_TextDisplayed.text = "";
            StartCoroutine(TypeFirstSequence());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_TextDisplayed.text == m_sentences[index] && index != m_sentences.Length-1 ) m_ContinueText.SetActive(true);
        else  m_ContinueText.SetActive(false);

        if(m_sentences.Length-1 == index && !Happened) 
        {
            if(cases == 0)
            {
                m_Menu.GetComponent<EndMenu>().EnterMenu();
            }
            else m_Menu.GetComponent<MainMenu>().EnterMenu();
            

            
            Happened = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && m_ContinueText.active)
        {
            NextSentence();
        }

    }
}
