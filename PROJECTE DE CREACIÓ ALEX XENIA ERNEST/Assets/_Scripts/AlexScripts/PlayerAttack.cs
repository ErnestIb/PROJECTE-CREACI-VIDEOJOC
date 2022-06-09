using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] Transform _BowPivot;
    [SerializeField] GameObject _ArrowPrefab;
    [SerializeField] GameObject _ArrowHand;
    [SerializeField] Transform _ArrowHandPos;
    [SerializeField] SpriteRenderer ArrowGFX;
    [SerializeField] Transform _Bow;
    [SerializeField] SpriteRenderer BowGFX;
    [SerializeField] Material _materialArrow;
    [SerializeField] GameObject _ArrowParticle;

    [SerializeField] AudioSource audioSource4;
    // [SerializeField] der _Powerder;

    private float _BowCharge;
    private float _MaxBowCharge = 20;
    private float _BaseBowPower = 4;
    float _Damage;
    float _ChargeColor;
    bool _ParticleFired;

    private float fireCooldown = 0.4f;
    private float lastFireTime;



    public void Start()
    {
        // BowGFX.enabled = false;
    }

    void Update()
    {
        RotateBow();
        if(CanFire()) BowInput();
    }
    private bool CanFire()
    {
       return (lastFireTime + fireCooldown) < Time.time;
    }

    void BowInput()
    {

        // Pasar este metodo a New Input System
        if(Input.GetMouseButton(0))
        {
            BowCharge();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            FireBow();
        }
    }


    void BowCharge()
    {
        ArrowGFX.enabled = true;
        _BowCharge += 20*Time.deltaTime;
        // _Powerder.value = _BowCharge;

        _materialArrow.SetColor("_EmissionColor", Color.white*_BowCharge/2.5f);    
        if(_BowCharge >= _MaxBowCharge && !_ParticleFired )
        {
            Debug.Log("ParticleEmitted");
            _ParticleFired = true;
            Instantiate(_ArrowParticle, _ArrowHandPos.position, Quaternion.identity);
            AudioManager.PlaySound("Blink", audioSource4);
        }    
        if(_BowCharge > _MaxBowCharge) {
            _BowCharge = _MaxBowCharge;
            Debug.Log("Max reached");

            //AudioManager.PlaySound("Blink", GetComponent<AudioSource>());
        }

    }

    void FireBow()
    {
        if(_BowCharge > _MaxBowCharge) _BowCharge = _MaxBowCharge;
        float arrowSpeed = _BowCharge + _BaseBowPower;

        float angle = Utility.AngleTowardsMouse(_Bow.position);
        Quaternion arrowRotation = Quaternion.Euler(new Vector3(0,0,angle));
        
        var arrow = Instantiate(_ArrowPrefab,_Bow.position,arrowRotation);
        arrow.GetComponent<ArrowBehaivour>().Init(arrowSpeed,_BowCharge/2.5f);

        ArrowGFX.enabled = false;
        ArrowGFX.color = Color.white;
        _ParticleFired = false;

        AudioManager.PlaySound("Arrow", audioSource4);

        _BowCharge = 0;
        lastFireTime = Time.time;
    }
    

    //
    // COMBAT
    //

    void RotateBow()
    {
        float angleToRotate = Utility.AngleTowardsMouse(_BowPivot.position);
        _BowPivot.rotation = Quaternion.Euler(new Vector3(0,0,angleToRotate));
    }

}
