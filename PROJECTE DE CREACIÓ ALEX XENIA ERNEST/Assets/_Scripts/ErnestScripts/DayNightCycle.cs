using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    public Light2D sun;

    [SerializeField]
    public Light2D playerLight;

    [SerializeField]
    public Light2D shopLight;

    public float time;
    
    public LightningScript lightningScript;
    // Start is called before the first frame update
    void Start()
    {
        sun.intensity = 1;
        playerLight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightningScript.time==10)
        {
            sun.intensity += 2;
            Invoke("RemoveLlamp", 0.2f);
            sun.intensity += 2;
            Invoke("RemoveLlamp", 0.2f);
        }
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
        if (sun.intensity != 1)
        {
            sun.intensity = sun.intensity + 0.0001f;
        }
        
        PlayerLightIntensity(-0.001f);
        ShopLightIntensity(-0.001f);

    }

    public void Sunset()
    {
        if (sun.intensity > 0.3)
        {
            sun.intensity = sun.intensity - 0.0001f;
        }
        
        PlayerLightIntensity(0.001f);
        ShopLightIntensity(0.001f);

    }
    
    public void RemoveLlamp()
    {
        sun.intensity -= 2;
    }

    public void PlayerLightIntensity(float intensity)
    {
        if(!(playerLight.intensity>=0.54))
        playerLight.intensity += intensity;
    }

    public void ShopLightIntensity(float intensity)
    {
        if (!(shopLight.intensity >= 0.54))
            shopLight.intensity += intensity;
    }

}
