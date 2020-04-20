using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpeedPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().addSpeedPotion();
            Destroy(gameObject);
        }
    }
}
