using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
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
}
