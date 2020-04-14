using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Goblin", menuName = "Goblin")]
public class GoblinStats : ScriptableObject
{
    public float health;
    public int level;
    public float def;
    public float attack;
}
