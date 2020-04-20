using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAttackPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().addAttackPotion();
            Destroy(gameObject);
        }
    }
}
