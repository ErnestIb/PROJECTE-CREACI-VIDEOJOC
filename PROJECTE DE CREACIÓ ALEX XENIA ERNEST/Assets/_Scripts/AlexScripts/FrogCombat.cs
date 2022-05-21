using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  

public class FrogCombat : MonoBehaviour
{
     
     

    [SerializeField] Transform _firePoint;
    [SerializeField] ChargedBlastBehaviour _chargedBlast;
    [SerializeField] GameObject _chargedParticle;


     
    float _chargeTime;
    float _chargeTimeDefault = 1f;
    float _damage = 50f;
    float _speed = 10f;
    bool _canFire;
    bool _canTransform;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BlastInput();
    }
    void BlastInput()
    {
        if(Input.GetMouseButton(0))
        {
            BlastMoveCharger();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            BlastMoveRelease();
        }
    }
    void BlastMoveCharger()
    {
        _chargeTime -= Time.deltaTime;
        Debug.Log("Charging");

        if(_chargeTime <= 0 && !_canFire)
        {
            _canFire = true;
            Instantiate(_chargedParticle, _firePoint.position, Quaternion.identity);
            Debug.Log("FinishedCharging");
        }

    }
    void BlastMoveRelease()
    {
        _chargeTime = _chargeTimeDefault;
        if(_canFire)
        {
            
            Debug.Log("Fired!");    
            float angle = Utility.AngleTowardsMouse(_firePoint.transform.position);
            Quaternion blastRotation = Quaternion.Euler(new Vector3(0,0,angle));

            var blast = Instantiate(_chargedBlast, _firePoint.position,blastRotation);
            blast.Init(_speed,_damage);
        }
        _canFire = false;
    }

}

