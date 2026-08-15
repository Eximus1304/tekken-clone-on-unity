using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthBar;

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateHealthBar();

        Debug.Log(
            gameObject.name +
            " took " +
            damage +
            " damage. Health: " +
            currentHealth
        );
    }

    void UpdateHealthBar()
    {
        if (healthBar == null)
        {
            Debug.LogError(
                gameObject.name + " has NO health bar!"
            );
            return;
        }

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }
}