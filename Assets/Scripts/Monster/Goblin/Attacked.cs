using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacked : MonoBehaviour
{
    public bool attack = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            attack = false;
        }
    }
}
