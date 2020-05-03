using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    [SerializeField] Recognized enemy;
    [SerializeField] Attacked thePlayer;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float moveTime = 5f;
    [SerializeField] float stopTime = 3f;
    [SerializeField] Animator animator;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] GoblinStats stats;
    GameObject player;
    float distanceX;
    float distanceY;
    bool busy = true;
    float moveTimeStop;
    float stopTimeStop;
    int direction;
    bool attacking;
    private IEnumerator Start()
    {
        player = GameObject.Find("Player");
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
            setAnimation(0, 1, 1, direction);
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }
        else if (direction == 2)
        {
            setAnimation(1, 0, 1, direction);
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else if (direction == 3)
        {
            setAnimation(0, -1, 1, direction);
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }
        else if (direction == 4)
        {
            setAnimation(-1, 0, 1, direction);
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
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
        AttackPointChange();
        if (attacking == false)
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
                attacking = true;
                setAnimation(0, 0, 0, direction);
                animator.SetBool("Attack", true);
            }
        }
    }

    private void endAttack()
    {
        attacking = false;
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
            setAnimation(0, 0, 0, direction);
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
    private void AttackPointChange()
    {
        if (direction == 1)
        {
            attackPoint.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }
        else if (direction == 2)
        {
            attackPoint.transform.position = new Vector2(transform.position.x + 0.7f, transform.position.y);
        }
        else if (direction == 3)
        {
            attackPoint.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        }
        else if (direction == 4)
        {
            attackPoint.transform.position = new Vector2(transform.position.x - 0.7f, transform.position.y);
        }
    }

    private void Hit()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        if (hit.Length > 0)
        {
            hit[0].GetComponent<PlayerStats>().takeDamage(stats.damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void setAnimation(float horizontal, float vertical, float speed, int direct) 
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", speed);
        animator.SetInteger("Direction", direct);
    }

    private void chasePlayer()
    {
        Vector2 targetPosition = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        distanceX = Mathf.Abs(targetPosition.x - transform.position.x);
        distanceY = Mathf.Abs(targetPosition.y - transform.position.y);
        if (transform.position.x < targetPosition.x)
        {
            if (transform.position.y < targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    setAnimation(0, 1, 1, 1);
                    direction = 1;
                }
                else if (distanceX > distanceY)
                {
                    setAnimation(1, 0, 1, 2);
                    direction = 2;
                }
            }
            else if (transform.position.y > targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    setAnimation(0, -1, 1, 3);
                    direction = 3;
                }
                else if (distanceX > distanceY)
                {
                    setAnimation(1, 0, 1, 2);
                    direction = 2;
                }
            }
        }
        else if (transform.position.x > targetPosition.x)
        {
            if (transform.position.y < targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    setAnimation(0, 1, 1, 1);
                    direction = 1;
                }
                else if (distanceX > distanceY)
                {
                    setAnimation(-1, 0, 1, 4);
                    direction = 4;
                }
            }
            else if (transform.position.y > targetPosition.y)
            {
                if (distanceX < distanceY)
                {
                    setAnimation(0, -1, 1, 3);
                    direction = 3;
                }
                else if (distanceX > distanceY)
                {
                    setAnimation(-1, 0, 1, 4);
                    direction = 4;
                }
            }
        }
    }
}
