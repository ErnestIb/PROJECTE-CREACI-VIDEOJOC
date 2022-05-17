using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public GameObject powerupPrefab;

    public List<PowerUp> powerups;

    public Dictionary<PowerUp, float> activePowerups = new Dictionary<PowerUp, float>();

    private List<PowerUp> keys = new List<PowerUp>();

    public int timer = 0;

    // Update is called once per frame
    void Update()
    {
        HandleActivePowerups();

        
        if(timer == 5000)
        RandomSpawnPowerups();

        timer++;
    }

    public void RandomSpawnPowerups()
    {
        SpawnPowerup(powerups[Random.Range(0,3)],new Vector3(Random.Range(-123.0f, -65.0f), Random.Range(-14.0f, 20.0f), 0));

        timer = 0;
    }

    public void HandleActivePowerups()
    {
        bool changed = false;

        if (activePowerups.Count > 0)
        {
            foreach(PowerUp powerup in keys)
            {
                if (activePowerups[powerup] > 0)
                {
                    activePowerups[powerup] -= Time.deltaTime;
                }
                else
                {
                    changed = true;

                    activePowerups.Remove(powerup);

                    powerup.End();

                }
            }
        }

        if (changed)
        {
            keys = new List<PowerUp>(activePowerups.Keys);
        }
    }

    public void ActivatePowerup(PowerUp powerup)
    {
        if (!activePowerups.ContainsKey(powerup))
        {
            powerup.Start();
            activePowerups.Add(powerup, powerup.duration);
        }
        else
        {
            activePowerups[powerup] += powerup.duration;
        }

        keys = new List<PowerUp>(activePowerups.Keys);
    }

    public GameObject SpawnPowerup(PowerUp powerup, Vector3 position)
    {
        GameObject powerupGameObject = Instantiate(powerupPrefab);

        var powerupBehaviour = powerupGameObject.GetComponent<PowerupBehaviour>();

        powerupBehaviour.controller = this;

        powerupBehaviour.SetPowerup(powerup);

        powerupGameObject.transform.position = position;


        return powerupGameObject;
    }
}
