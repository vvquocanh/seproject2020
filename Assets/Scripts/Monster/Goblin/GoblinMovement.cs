using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speed = 5f;
    [SerializeField] Recognized enemy;
    [SerializeField] float moveTime = 5f;
    [SerializeField] float stopTime = 3f;
    [SerializeField] PlayerMovement player;
    [SerializeField] Attacked thePlayer;
    float distanceX;
    float distanceY;
    bool busy = true;
    float moveTimeStop;
    float stopTimeStop;
    int direction;
    private IEnumerator Start()
    {
        stopTimeStop = stopTime;
        moveTimeStop = moveTime;
        direction = Random.Range(1, 5);
        yield return new WaitForSeconds(4);
        busy = false;
    }   

    private void moveIdle()
    {
        if (direction == 1)
        {
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("Speed", 1);
            animator.SetInteger("Direction", direction);
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (direction == 2)
        {
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Speed", 1);
            animator.SetInteger("Direction", direction);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (direction == 3)
        {
            animator.SetFloat("Vertical", -1);
            animator.SetFloat("Speed", 1);
            animator.SetInteger("Direction", direction);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if (direction == 4)
        {
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Speed", 1);
            animator.SetInteger("Direction", direction);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void resetAnimation()
    {
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 0);
        animator.SetFloat("Speed", 0);
    }

    private void setNextDirection()
    {
        if (direction == 1)
        {
            direction = 3;
        }
        else if (direction == 2)
        {
            direction = 4;
        } else if (direction == 3)
        {
            direction = 1;
        } else if (direction == 4)
        {
            direction = 2;
        }
    }

    private void Update()
    {
        if (thePlayer.attack == false)
        {
            animator.SetBool("Attack", false);
            if (enemy.recognized == false)
            {
                if (busy == false)
                {
                    moveIdleState();
                }
            }
            else if (enemy.recognized == true)
            {
                chasePlayer();
            }
        }
        else if (thePlayer.attack == true)
        {
            resetAnimation();
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetBool("Attack", true);
    }

    private void moveIdleState()
    {
        if (moveTimeStop > 0)
        {
            moveIdle();
            moveTimeStop -= Time.deltaTime;
        }
        else if (moveTimeStop <= 0)
        {
            resetAnimation();
            if (stopTimeStop > 0)
            {
                stopTimeStop -= Time.deltaTime;
            }
            else if (stopTimeStop <= 0)
            {
                moveTimeStop = moveTime;
                stopTimeStop = stopTime;
                setNextDirection();
            }
        }
    }

    private void chasePlayer()
    {
        Vector2 targetPosition = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
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
                    animator.SetFloat("Speed", 1);
                    animator.SetInteger("Direction", 1);
                }
                else if (distanceX > distanceY)
                {
                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", 1);
                    animator.SetFloat("Speed", 1);
                    animator.SetInteger("Direction", 2);
                }
            }
            else if (transform.position.y > targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", -1);
                    animator.SetFloat("Speed", 1);
                    animator.SetInteger("Direction", 3);
                }
                else if (distanceX > distanceY)
                {
                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", 1);
                    animator.SetFloat("Speed", 1);
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
                    animator.SetFloat("Speed", 1);
                    animator.SetInteger("Direction", 1);
                }
                else if (distanceX > distanceY)
                {
                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", -1);
                    animator.SetFloat("Speed", 1);
                    animator.SetInteger("Direction", 4);
                }
            }
            else if (transform.position.y > targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    animator.SetFloat("Horizontal", 0);
                    animator.SetFloat("Vertical", -1);
                    animator.SetFloat("Speed", 1);
                    animator.SetInteger("Direction", 3);
                }
                else if (distanceX > distanceY)
                {
                    animator.SetFloat("Vertical", 0);
                    animator.SetFloat("Horizontal", -1);
                    animator.SetFloat("Speed", 1);
                    animator.SetInteger("Direction", 4);
                }
            }
        }
    }
}
