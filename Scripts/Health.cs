using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        // Check if the target's health has reached zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement death logic here (e.g., destroy the object)
        Destroy(gameObject);
    }
}
