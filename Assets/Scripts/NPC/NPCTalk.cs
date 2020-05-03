using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NPCTalk : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string[] dialog;
    public bool playerInRange;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            } 
            else
            {
                int i = Random.Range(0, 5);
                dialogBox.SetActive(true);
                dialogText.text = dialog[i];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Foot")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Foot")
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
