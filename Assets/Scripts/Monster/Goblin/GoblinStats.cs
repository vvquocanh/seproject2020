using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinStats : MonoBehaviour
{   
    [Header("Stats")]
    [SerializeField] float level = 1f;
    [SerializeField] float health = 477f;
    [SerializeField] float damage = 12f;
    [SerializeField] float armor = 0f;
    [SerializeField] float exp = 60f;
    float currentHealth;
    private void Start()
    {
        Initalize();
    }

    private void Initalize()
    {
        health += 20f * (level - 1);
        currentHealth = health;
        damage += 0.7f * (level - 1);
        armor += 0.2f * (level - 1);
        exp += 5 * (level - 1);
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
