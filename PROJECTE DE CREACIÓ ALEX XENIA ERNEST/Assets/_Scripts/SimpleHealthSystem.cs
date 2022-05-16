using UnityEngine;

public class SimpleHealthSystem : MonoBehaviour, IDamageTaker
{
    public void TakeDamage(float amount)
    {
        Debug.Log("Damage: " + amount);
    }
}
