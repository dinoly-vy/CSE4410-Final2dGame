using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private DeathScreen deathScreenScript;
    [SerializeField] private HealthBarUI healthBarUI;

    private int currentHealth;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;

        if (healthBarUI != null)
        {
            healthBarUI.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

    public void Hurt(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"Health: {currentHealth}");

        if (healthBarUI != null)
        {
            healthBarUI.UpdateHealthBar(currentHealth, maxHealth);
        }
        else
        {
            Debug.LogError("HealthBarUI is not assigned on PlayerHealth.");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead)
            return;

        isDead = true;

        Debug.Log("Player has died!");

        if (healthBarUI != null)
        {
            healthBarUI.HideHealthBar();
        }

        if (deathScreenScript != null)
        {
            deathScreenScript.ShowDeathScreen();
        }
        else
        {
            Debug.LogError("DeathScreenScript is not assigned on PlayerHealth.");
        }
    }
}