using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{

    [SerializeField]
    public ParticleSystem rain;

    [SerializeField]
    public ParticleSystem bigRain;

    public DayNightCycle dayNight;

    public bool isRaining = false;

    void Start()
    {
        rain.gameObject.SetActive(false);
        bigRain.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dayNight.time == 600/*dayNight.time % 2000 == 0*/)
        {
            Rain();
            if (Random.Range(1, 3) == 1)
            {
                
                //Rain();
            }
        }

       
    }

    public void Clouds()
    {
        dayNight.sun.intensity -= 0.08f;
    }

    public void NoClouds()
    {
        dayNight.sun.intensity += 0.08f;
    }

    public void StartRaining()
    {
        
        rain.gameObject.SetActive(true);
        bigRain.gameObject.SetActive(true);
        var emissions = rain.emission.rateOverTime;
        emissions = 5;

        isRaining = true;
       
    }

    public void MoreRain1()
    {
        var emissions = rain.emission.rateOverTime;
        emissions = 20;
    }

    public void MoreRain2()
    {
        var emissions = rain.emission.rateOverTime;
        emissions = 50;
    }

    public void MoreRain3()
    {
        var emissions = rain.emission.rateOverTime;
        emissions = 100;
    }

    public void EndRain()
    {
        
        rain.gameObject.SetActive(false);
        bigRain.gameObject.SetActive(false);

        isRaining = false;
    }

    public void Rain()
    {
        Clouds();
        Invoke("Clouds", 2);
        Invoke("Clouds", 3);
        Invoke("StartRaining", 5);
        Invoke("MoreRain1", 30);
        Invoke("MoreRain2", 50);
        Invoke("MoreRain3", 80);
        Invoke("MoreRain2", 100);
        Invoke("MoreRain1", 110);
        Invoke("StartRaining", 130);
        Invoke("NoClouds", 135);
        Invoke("NoClouds", 140);
        Invoke("NoClouds", 145);
        Invoke("EndRain", 145);
        
    }
}
