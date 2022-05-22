using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformingScript : MonoBehaviour
{

    [SerializeField] GameObject _transformation;
    [SerializeField] GameObject _smokeScreen;

    public void EnablePlayer()
    {
        Instantiate(_smokeScreen,_transformation.transform.position, Quaternion.identity);
    }

    public void DisablePlayer()
    {
        _transformation.SetActive(true);
        _transformation.transform.position = transform.position ;
        gameObject.SetActive(false);

        _transformation.GetComponent<TransformingScript>().EnablePlayer();
    }
}
