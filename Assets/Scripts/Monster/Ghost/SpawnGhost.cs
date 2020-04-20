using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    [SerializeField] float waitTime = 10f;
    float currentTime;
    [SerializeField] GameObject ghost;
    GameObject checkGhost;

    private void Start()
    {
        checkGhost = Instantiate(ghost, transform.position, Quaternion.identity);
        currentTime = waitTime;
    }

    private void Update()
    {
        if (checkGhost == null)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else if (currentTime <= 0)
            {
                checkGhost = Instantiate(ghost, transform.position, Quaternion.identity);
                currentTime = waitTime;
            }
        }
    }
}
