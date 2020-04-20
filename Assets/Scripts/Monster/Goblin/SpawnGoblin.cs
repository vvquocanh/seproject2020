using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoblin : MonoBehaviour
{
    [SerializeField] float waitTime = 10f;
    float currentTime;
    [SerializeField] GameObject goblin;
    GameObject checkGoblin;

    private void Start()
    {
        checkGoblin = Instantiate(goblin, transform.position, Quaternion.identity);
        currentTime = waitTime;
    }

    private void Update()
    {
        if (checkGoblin == null)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else if (currentTime <= 0)
            {
                checkGoblin = Instantiate(goblin, transform.position, Quaternion.identity);
                currentTime = waitTime;
            }
        }
    }
}
