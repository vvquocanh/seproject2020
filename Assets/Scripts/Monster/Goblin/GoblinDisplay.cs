using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GoblinDisplay : MonoBehaviour
{
    [SerializeField] GoblinStats goblin;
    [SerializeField] TextMeshPro text;
    void Update()
    {
        text.text = goblin.level.ToString() + "\n" + goblin.currentHealth.ToString() + "/" + goblin.health.ToString();
    }
}

