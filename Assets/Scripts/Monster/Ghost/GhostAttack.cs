using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{
    public bool attack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        attack = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attack = false;

    }
}
