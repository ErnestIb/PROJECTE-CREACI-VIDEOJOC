using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformingScript : MonoBehaviour
{

    [SerializeField] GameObject _transformation;
    [SerializeField] GameObject _smokeScreen;
    public void LateUpdate()
    {
       if(Input.GetKeyUp(KeyCode.R))
        {
            DisablePlayer();
        } 
    }

    public void EnablePlayer()
    {
        Instantiate(_smokeScreen,_transformation.transform.position, Quaternion.identity);
        _transformation.transform.position = transform.position ;
    }

    public void DisablePlayer()
    {
        _transformation.SetActive(true);
        gameObject.SetActive(false);

        _transformation.GetComponent<TransformingScript>().EnablePlayer();
    }
}
