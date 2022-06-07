using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaivour : MonoBehaviour
{
    public GameObject _ArrowPrefab;

    public float _baseDamage;
    private float _speed;
    private float _lifeTime = 10;
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
        return 10+_speed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageTaker = other.GetComponent<ITakeDamage>();
        if (damageTaker != null && other.gameObject.tag == ("Enemy"))
        {
            damageTaker.TakeDamage(DamageCalculator());
        }
        else
        {
            AudioManager.PlaySound("ImpactMap", GetComponent<AudioSource>());
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
