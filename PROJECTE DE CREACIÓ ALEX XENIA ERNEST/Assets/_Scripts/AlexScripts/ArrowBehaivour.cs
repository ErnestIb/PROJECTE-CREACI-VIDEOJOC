using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaivour : MonoBehaviour
{
    public GameObject _ArrowPrefab;

    private float _speed;
    private float _lifeTime = 4;
    private Vector2 direction;

    public Rigidbody2D _rigidBody;
    public Collider _collider;
    private Material _material;

    public void Init(float speed,float shotColor)
    {
        _speed = speed;
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = transform.right * _speed;
        _material = GetComponent<Renderer>().material;
        _material.SetColor("_EmissionColor", Color.white*shotColor);
    }
    float DamageCalculator()
    {
        return _speed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageTaker = other.GetComponent<ITakeDamage>();
        if (damageTaker != null)
        {
            damageTaker.TakeDamage(DamageCalculator());
        }
        Destroy(gameObject);
    }

    void DestroyOverTime()
    {
        _lifeTime -= Time.deltaTime;
        if(_lifeTime <= 0) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOverTime();
    }



    


}
