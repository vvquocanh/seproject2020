using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDefensePotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().addDefensePotion();
            Destroy(gameObject);
        }
    }
}
