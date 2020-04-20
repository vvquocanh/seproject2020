using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealthPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().addHealthPotion();
            Destroy(gameObject);
        }
    }
}
