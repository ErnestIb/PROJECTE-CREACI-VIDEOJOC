using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformingScript : MonoBehaviour
{

    [SerializeField] GameObject _transformation;
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
        transform.position = _transformation.transform.position;
        Instantiate(_smokeScreen,_transformation.transform.position, Quaternion.identity);
    }

    void DisablePlayer()
    {
        _transformation.SetActive(true);
        _transformation.GetComponent<TransformingScript>().EnablePlayer();
        gameObject.SetActive(false);
    }
}
