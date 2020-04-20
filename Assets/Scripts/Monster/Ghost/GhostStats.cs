using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStats : MonoBehaviour
{
    [SerializeField] float level = 1f;
    [SerializeField] float health = 296f;
    [SerializeField] float damage = 20f;
    [SerializeField] float armor = 0f;
    [SerializeField] float exp = 30f;
    float currentHealth;

    private void Start()
    {
        Initalize();
    }

    private void Initalize()
    {
        health += 6f * (level - 1);
        currentHealth = health;
        damage += 1.5f * (level - 1);
        armor += 0 * (level - 1);
        exp += 2 * (level - 1);
    }

    public void TakeDamage(float damageTake)
    {
        currentHealth -= (100f / (100f + armor)) * damageTake;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
