using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [Header("Idle")]
    [SerializeField] int direction;
    [SerializeField] Animator animator;
    [SerializeField] GhostAttack ghost;
    
    [Header("Attack")]
    GameObject player;
    [SerializeField] GameObject projectile;
    [SerializeField] float waitTime;
    float currentTime;
    float distanceX, distanceY;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = waitTime;
        player = GameObject.Find("Player");
        direction = Random.Range(1, 5);
        animator.SetInteger("Direction", direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (ghost.attack == true)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else if (currentTime <= 0)
            {
                Attack();
                currentTime = waitTime;
            }
            
        } else if (ghost.attack == false)
        {
            animator.SetBool("Attack", false);
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        animator.SetBool("Attack", false);
    }

    private void setAnimation(float horizontal, float vertical, int direct)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetInteger("Direction", direct);
    }

    private void Attack()
    {
        animator.SetBool("Attack", true);
        Vector2 targetPosition = player.transform.position;
        distanceX = Mathf.Abs(targetPosition.x - transform.position.x);
        distanceY = Mathf.Abs(targetPosition.y - transform.position.y);
        if (transform.position.x < targetPosition.x)
        {
            if (transform.position.y < targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    setAnimation(0, 1, 1);
                }
                else if (distanceX > distanceY)
                {
                    setAnimation(1, 0, 2);
                }
            }
            else if (transform.position.y > targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    setAnimation(0, -1, 3);
                }
                else if (distanceX > distanceY)
                {
                    setAnimation(1, 0, 2);
                }
            }
        }
        else if (transform.position.x > targetPosition.x)
        {
            if (transform.position.y < targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    setAnimation(0, 1, 1);
                }
                else if (distanceX > distanceY)
                {
                    setAnimation(-1, 0, 4);
                }
            }
            else if (transform.position.y > targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    setAnimation(0, -1, 3);
                }
                else if (distanceX > distanceY)
                {
                    setAnimation(-1, 0, 4);
                }
            }
        }
    }
}
