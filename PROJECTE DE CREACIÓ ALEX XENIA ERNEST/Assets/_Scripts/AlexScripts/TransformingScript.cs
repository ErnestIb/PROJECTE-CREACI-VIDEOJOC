using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformingScript : MonoBehaviour
{

    [SerializeField] GameObject _Frog;
    [SerializeField] GameObject _smokeScreen;
    void Start()
    {

    }
    void LateUpdate()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            DisablePlayer();
        }
    }

    public void EnablePlayer()
    {
        transform.position = _Frog.transform.position;
        Instantiate(_smokeScreen,_Frog.transform.position, Quaternion.identity);
    }

    void DisablePlayer()
    {
        _Frog.SetActive(true);
        _Frog.GetComponent<FrogTransformation>().EnableFrog();
        gameObject.SetActive(false);
    }
}
