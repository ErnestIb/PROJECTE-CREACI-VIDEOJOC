using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UllEnemic : MonoBehaviour//, ITakeDamage
{
    public float Speed = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageTaker = other.GetComponent<ITakeDamage>(); // Cambiar per el tag
        if(damageTaker != null)
        {
            damageTaker.TakeDamage(5.0f);
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
