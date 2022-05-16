using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UllEnemic : MonoBehaviour
{
    public float Speed = 5f;
    public float damage = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageTaker = other.GetComponent<ITakeDamage>();
        if(other.CompareTag("Player"))
        {
            damageTaker.TakeDamage(damage);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -Speed) * Time.deltaTime);
    }
}
