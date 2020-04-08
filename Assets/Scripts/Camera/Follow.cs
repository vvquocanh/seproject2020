using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
        transform.position = playerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
        transform.position = playerPosition;
    }
}
