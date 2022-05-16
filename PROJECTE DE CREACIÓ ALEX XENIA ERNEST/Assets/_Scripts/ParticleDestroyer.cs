using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    // Start is called before the first frame update

    public float autodestroyTimer = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        autodestroyTimer -= Time.deltaTime;
        if (autodestroyTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
