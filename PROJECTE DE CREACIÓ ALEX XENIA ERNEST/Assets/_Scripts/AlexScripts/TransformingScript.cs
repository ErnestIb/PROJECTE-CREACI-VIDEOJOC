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
        transform.position = _transformation.transform.position;
        AudioManager.PlaySound("Transform", GetComponent<AudioSource>());

    }

    public void DisablePlayer()
    {
        _transformation.SetActive(true);
        _transformation.GetComponent<TransformingScript>().EnablePlayer();
        gameObject.SetActive(false);
        AudioManager.PlaySound("Transform", GetComponent<AudioSource>());

    }
}
