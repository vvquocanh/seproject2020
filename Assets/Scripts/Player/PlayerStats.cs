using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    [SerializeField] PlayerMovement player;

    [Header("Normal stats")]
    public int level;
    public float maxExp;
    public float currentExp;
    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float defense;

    [Header("Potion")]
    public int healthPotion = 5;
    public int maxHPPotion = 0;
    public int speedPotion = 0;
    public int attackPotion = 0;
    public int defensePotion = 0;

    [Header("Potion Text")]
    public TextMeshProUGUI healthPotionText;
    public TextMeshProUGUI maxHPPotionText;
    public TextMeshProUGUI speedPotionText;
    public TextMeshProUGUI attackPotionText;
    public TextMeshProUGUI defensePotionText;

    [Header("Time of Potion")]
    private float maxHPPotionTime = 0;
    private float speedPotionTime = 0;
    private float attackPotionTime = 0;
    private float defensePotionTime = 0;

    private void Start()
    {
        initializeStats();
        updateNumberOfPotion();
    }

    private void updateNumberOfPotion()
    {
        healthPotionText.text = healthPotion.ToString();
        maxHPPotionText.text = maxHPPotion.ToString();
        speedPotionText.text = speedPotion.ToString();
        attackPotionText.text = attackPotion.ToString();
        defensePotionText.text = defensePotion.ToString();
    }

    private void initializeStats()
    {
        level = 1;
        maxExp = 280f;
        currentExp = 0;
        maxHealth = 523f;
        currentHealth = maxHealth;
        damage = 60f;
        defense = 30f;
    }

    private void Update()
    {
        updateNumberOfPotion();
        potionTimeDecreasing();
    }

    public void useHealthPotion()
    {
        if (healthPotion > 0)
        {
            healthPotion--;
            currentHealth += maxHealth / 10;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    public void useMaxHPPotion()
    {
        if (maxHPPotion > 0)
        {
            maxHPPotion--;
            if (maxHPPotionTime > 0)
            {
                maxHPPotionTime = 30f;
            }
            else if (maxHPPotionTime <= 0)
            {
                maxHealth = maxHealth * 2;
                maxHPPotionTime = 30f;
            }
        }
    }

    public void useSpeedPotiom()
    {
        if (speedPotion > 0)
        {
            speedPotion--;
            if (speedPotionTime > 0)
            {
                speedPotionTime = 30f;
            }
            else if (speedPotionTime <= 0)
            {
                player.movementSpeed = player.movementSpeed * 2;
                speedPotionTime = 30f;
            }
        }
    }

    public void useAttackPotion()
    {
        if (attackPotion > 0)
        {
            attackPotion--;
            if (attackPotionTime > 0)
            {
                attackPotionTime = 30f;
            }
            else if (attackPotionTime <= 0)
            {
                damage = damage * 2;
                attackPotionTime = 30f;
            }
        }
    }

    public void useDefensePotion()
    {
        if (defensePotion > 0)
        {
            defensePotion--;
            if (defensePotionTime > 0)
            {
                defensePotionTime = 30f;
            }
            else if (defensePotionTime <= 0)
            {
                defense = defense * 2;
                defensePotionTime = 30f;
            }
        }
    }

    private void potionTimeDecreasing()
    {
        if (maxHPPotionTime > 0)
        {
            maxHPPotionTime -= Time.deltaTime;
            if (maxHPPotionTime <= 0)
            {
                maxHealth = maxHealth / 2;
            }
        }
        if (attackPotionTime > 0)
        {
            attackPotionTime -= Time.deltaTime;
            if (attackPotionTime <= 0)
            {
                damage = damage / 2;
            }
        }
        if (speedPotionTime > 0)
        {
            speedPotionTime -= Time.deltaTime;
            if (speedPotionTime <= 0)
            {
                player.movementSpeed = player.movementSpeed / 2;
            }
        }
        if (defensePotionTime > 0)
        {
            defensePotionTime -= Time.deltaTime;
            if (defensePotionTime <= 0)
            {
                defense = defense / 2;
            }
        }
    }

    public void addHealthPotion()
    {
        healthPotion++;
    }

    public void addMaxHPPotion()
    {
        maxHPPotion++;
    }

    public void addSpeedPotion()
    {
        speedPotion++;
    }

    public void addAttackPotion()
    {
        attackPotion++;
    }

    public void addDefensePotion()
    {
        defensePotion++;
    }

    public void takeDamage(float enemyDamage)
    {
        currentHealth -= ((100f / (100f + defense) * enemyDamage));
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
