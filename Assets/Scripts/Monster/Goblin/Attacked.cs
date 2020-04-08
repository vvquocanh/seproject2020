using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacked : MonoBehaviour
{
    public bool attack = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        attack = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attack = false;
    }
}
