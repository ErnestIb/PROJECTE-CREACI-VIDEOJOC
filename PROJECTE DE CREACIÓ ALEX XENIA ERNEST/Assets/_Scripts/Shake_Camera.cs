using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_Camera : MonoBehaviour
{
    public Animator shake;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Shake()
    {
        shake.SetTrigger("Shake");
        Debug.Log("Shake has initiaded");

    }
}
