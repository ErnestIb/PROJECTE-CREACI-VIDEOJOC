using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float Damage = 5.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<IDamageTaker>();
        if (health != null)
        {
            health.TakeDamage(Damage);
        }
    }
}
