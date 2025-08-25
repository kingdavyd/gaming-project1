using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject ragdoll;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        Debug.Log("Player's Health: " + health); // Log the updated health

        if (health <= 0)
        {
            Debug.Log("You died");
            Respawn();
        }
    }

    public void HitVFX(Vector3 hitPosition)
    {
        GameObject hit = Instantiate(hitVFX, hitPosition, Quaternion.identity);
        Destroy(hit, 3f);
    }

    public void Respawn()
    {
        SceneManager.LoadScene("RespawnMenu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public float GetCurrentHealth()
    {
        return health;
    }
}
