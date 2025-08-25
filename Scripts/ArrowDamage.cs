using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    public float arrowDamage = 10f;
    public float lifetime = 5f;

    public float timer = 0f;
    public void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the arrow collided with an object that has a health component
        Health targetHealth = collision.gameObject.GetComponent<Health>();

        if (targetHealth != null)
        {
            // Apply damage to the target
            targetHealth.TakeDamage(arrowDamage);
        }

        // Destroy the arrow on collision
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(gameObject);

        }
    }
}
