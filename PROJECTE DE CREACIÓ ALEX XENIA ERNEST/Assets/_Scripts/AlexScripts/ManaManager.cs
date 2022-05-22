using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManaManager : MonoBehaviour
{
    [SerializeField] GameObject _Frog;
    [SerializeField] GameObject _Ninja;

    [SerializeField] ManaBar _ManaBar;

    float _currentMana, _maxMana;
    bool _isTransformed;



    void Start()
    {
        _currentMana = _maxMana;
        _ManaBar.SetMaxMana((int)_maxMana);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ManaRecovery();
        ManaDeteoration();


        if(Input.GetKeyUp(KeyCode.R))
        {
            Transform();
        }
        _ManaBar.SetMana((int)_currentMana);
    }
    void ManaRecovery()
    {
        if(!_isTransformed)
        {
            if(_currentMana <= _maxMana)
            {
            _currentMana += Time.deltaTime/4;
            }

            if(_currentMana >= _maxMana) _maxMana = _currentMana;
        }
        
    }
    void ManaDeteoration()
    {
        if(_isTransformed)
        {
            _currentMana -=Time.deltaTime;
        }
    }


    void Transform()
    {
        if(_isTransformed)
        {
            _Ninja.GetComponent<TransformingScript>().DisablePlayer();
            _isTransformed = false;
        }
        else
        {
            _Frog.GetComponent<TransformingScript>().DisablePlayer();
            _isTransformed = true;
        }
    }
}
