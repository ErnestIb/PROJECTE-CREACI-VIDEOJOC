using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Timer;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerUpEffect
{
    public float amount;
    public float buffDuration = 5f;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovement>().activeSpeed += amount;

        aTimer = new System.Timers.Timer(1000 * 60 * 3);
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Enabled = true;
        target.GetComponent<PlayerMovement>().activeSpeed -= amount;

    }

    public void DeBuff(GameObject target)
    {
        target.GetComponent<PlayerMovement>().activeSpeed -= amount;
    }

    

}
