using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public Slider healthBar;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        UpdateHealthBar();

        Debug.Log(
            gameObject.name +
            " Health started. Slider = " +
            (healthBar != null ? healthBar.name : "NULL")
        );
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        Debug.Log(
            gameObject.name +
            " took " + damage +
            " damage. Health: " +
            currentHealth
        );

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log(gameObject.name + " KO!");
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar == null)
        {
            Debug.LogError(
                gameObject.name +
                " → HEALTH BAR IS NULL!"
            );

            return;
        }

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        Debug.Log(
            gameObject.name +
            " → Slider updated: " +
            healthBar.value
        );
    }
}