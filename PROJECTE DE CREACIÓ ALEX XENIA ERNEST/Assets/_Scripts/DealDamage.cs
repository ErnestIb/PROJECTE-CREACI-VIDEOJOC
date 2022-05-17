using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int Damage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<IDamageTaker>();
        if (health != null)
        {
            health.TakeDamage(Damage);
        }
    }
}
