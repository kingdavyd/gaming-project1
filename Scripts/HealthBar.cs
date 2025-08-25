using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public Image healthBar, ringHealthBar;
    public Image[] healthPoints;

    HealthSystem healthSystem; // Reference to the HealthSystem script
    float maxHealth = 100;
    float lerpSpeed;

    private void Start()
    {
        // Find and cache the HealthSystem script on the player GameObject
        healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
    }

    private void Update()
    {
        // Get the health value from the HealthSystem script
        float health = healthSystem.GetCurrentHealth();

        healthText.text = "Health: " + health + "%";
        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller(health);
        ColorChanger(health);
    }

    void HealthBarFiller(float health)
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);

        for (int i = 0; i < healthPoints.Length; i++)
        {
            healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        }
    }

    void ColorChanger(float health)
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
    }

    bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }
}
