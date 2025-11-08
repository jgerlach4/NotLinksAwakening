using UnityEngine;

// Example PlayerHealth script(attach to player GameObject)
    public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private HealthBar healthBar;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        { 
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Player took {damage} damage. Current health: {currentHealth}");
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Add your death logic here (respawn, game over, etc.)
    }
}