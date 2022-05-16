using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemic : MonoBehaviour, ITakeDamage
{
    public float life = 50;

    [SerializeField] List<Transform> wayPoints;
    public float velocity = 2;
    float distanciaCambio = 0.2f;
    byte siguientePos = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[siguientePos].transform.position, velocity * Time.deltaTime);

        if (Vector3.Distance(transform.position, wayPoints[siguientePos].transform.position) < distanciaCambio)
        {
            siguientePos++;
            if(siguientePos >= wayPoints.Count)
            {
                siguientePos = 0;
            }
        }
    }
    
    public void TakeDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
