using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogTransformation : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _smokeScreen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            DisableFrog();
        }
    }

    public void EnableFrog()
    {
        transform.position = _player.transform.position;
        Instantiate(_smokeScreen,_player.transform.position, Quaternion.identity);
    }

    void DisableFrog()
    {
        _player.SetActive(true);
        _player.GetComponent<TransformingScript>().EnablePlayer();
        gameObject.SetActive(false);
    }
}
