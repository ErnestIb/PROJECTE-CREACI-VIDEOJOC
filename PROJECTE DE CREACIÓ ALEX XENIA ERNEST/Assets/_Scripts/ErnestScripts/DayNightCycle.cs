using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    public Light2D sun;

    public float time;
    

    // Start is called before the first frame update
    void Start()
    {
        sun.intensity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time > 500)
        {
            if (time< 10000)
            {
                Sunset();
            }
            else if (time<19500)
            {
                Sunrise();
            }
            else
            {
                time = 0;
            }
            
            
        }
    }

    public void Sunrise()
    {
        if(sun.intensity!=1)
        sun.intensity = sun.intensity + 0.0001f;

    }

    public void Sunset()
    {
        if(sun.intensity>0.3)
        sun.intensity = sun.intensity - 0.0001f;

    }

}
