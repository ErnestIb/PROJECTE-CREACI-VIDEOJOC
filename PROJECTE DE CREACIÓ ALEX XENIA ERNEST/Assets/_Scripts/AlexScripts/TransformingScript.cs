using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformingScript : MonoBehaviour
{

    [SerializeField] GameObject _ThisPlayer;
    [SerializeField] GameObject _Frog;
    [SerializeField] GameObject _SmokeScreen;
    bool _canTransform;
    void Start()
    {
        _canTransform = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            DisablePlayer();
        }
        
    }

    public void EnablePlayer()
    {
        Instantiate(_SmokeScreen, _Frog.transform.position, Quaternion.identity);
        transform.position = _Frog.transform.position;
        _canTransform = true;
    }

    void DisablePlayer()
    {
        if(_canTransform)
        {
        _Frog.SetActive(true);
        _canTransform = false;
        _Frog.GetComponent<FrogMovement>().EnableFrog();
        _ThisPlayer.SetActive(false);
        }
    }
}
