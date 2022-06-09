using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedBlastBehaviour : MonoBehaviour
{
    public GameObject _blastPrefab;

    private float _speed;
    private float _lifeTime = 4;
    private float _damage = 30;

    private Rigidbody2D _rigidBody;
    private Collider2D _collider;

    public void Init(float speed, float damage)
    {
        _speed = speed;
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = transform.right * _speed;
        _collider = GetComponent<Collider2D>();
        _damage = damage;
    }
    float DamageCalculator()
    {
        return _damage;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageTaker = other.GetComponent<ITakeDamage>();
        if (damageTaker != null && other.gameObject.tag == ("Enemy"))
        {
            damageTaker.TakeDamage((int)DamageCalculator());
            Destroy(gameObject);
            AudioManager.PlaySound("Impact");
        }
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
