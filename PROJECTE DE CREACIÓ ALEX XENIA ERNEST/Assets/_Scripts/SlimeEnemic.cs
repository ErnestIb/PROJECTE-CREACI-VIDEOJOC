using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemic : MonoBehaviour, ITakeDamage
{
    private SpriteRenderer slime;

    public float life = 50;

    [SerializeField] List<Transform> wayPoints;
    public float velocity = 2;
    public float damage = 10;
    float distanciaCambio = 0.2f;
    byte siguientePos = 0;
    // Start is called before the first frame update
    void Start()
    {
        slime = GetComponent<SpriteRenderer>();
        
        transform.position = wayPoints[0].transform.position;
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

        Color newColor = new Color(255f / 255f, 100f / 255f, 100f / 255f);
        slime.color = newColor;

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageTaker = other.GetComponent<ITakeDamage>();
        if (other.CompareTag("Player"))
        {
            damageTaker.TakeDamage(damage);
        }
    }
}
