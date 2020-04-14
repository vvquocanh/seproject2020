using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] int direction;
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement player;
    [SerializeField] GhostAttack ghost;
    [SerializeField] GameObject projectile;
    float distanceX, distanceY;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(1, 5);
        animator.SetInteger("Direction", direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (ghost.attack == true)
        {
            Attack();
        } else if (ghost.attack == false)
        {
            animator.SetBool("Attack", false);
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
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
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", 1);
                    animator.SetInteger("Direction", 1);
                }
                else if (distanceX > distanceY)
                {
                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", 1);
                    animator.SetInteger("Direction", 2);
                }
            }
            else if (transform.position.y > targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", -1);
                    animator.SetInteger("Direction", 3);
                }
                else if (distanceX > distanceY)
                {
                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", 1);
                    animator.SetInteger("Direction", 2);
                }
            }
        }
        else if (transform.position.x > targetPosition.x)
        {
            if (transform.position.y < targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", 1);
                    animator.SetInteger("Direction", 1);
                }
                else if (distanceX > distanceY)
                {
                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", -1);
                    animator.SetInteger("Direction", 4);
                }
            }
            else if (transform.position.y > targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", -1);
                    animator.SetInteger("Direction", 3);
                }
                else if (distanceX > distanceY)
                {
                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", -1);
                    animator.SetInteger("Direction", 4);
                }
            }
        }
    }
}
