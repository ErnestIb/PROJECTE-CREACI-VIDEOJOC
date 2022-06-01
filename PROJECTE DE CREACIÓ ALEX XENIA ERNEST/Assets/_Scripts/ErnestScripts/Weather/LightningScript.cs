using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    public float time;

    [SerializeField]
    public ParticleSystem lightningPrefab;

    [SerializeField]
    public GameObject cinemachine;

    ParticleSystem lightning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        time++;
        if (time==10)
        Appear();
    }

    public void Appear()
    {
        lightning = Instantiate(lightningPrefab);
        lightning.gameObject.transform.position = new Vector3(Random.Range(cinemachine.transform.position.x+10, cinemachine.transform.position.x-10), cinemachine.transform.position.y+10, 10);
        if (time == 7)
        {
            lightning.gameObject.SetActive(false); 
        }

        Invoke("Die", 2);
        
        
    }

    public void Die()
    {
        lightning.gameObject.SetActive(false);
        time = 0;
    }

}
