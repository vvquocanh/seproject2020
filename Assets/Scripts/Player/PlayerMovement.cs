using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [Header("Movement")]
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] Animator animator;
    int direction = 3;
    Vector2 movement;

    [Header("Attack")]
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask goblinLayers;
    [SerializeField] LayerMask ghostLayers;
    [SerializeField] PlayerStats stats;
    bool attacking = false;
    void Update()
    {
        if (attacking == false)
        {
            takeInput();
            setAnimation();
            Move();
            AttackPointChange();
            Attack();
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

    private void Attack()
    {
        if (Input.GetKeyDown("space"))
        {
            attacking = true;
            animator.SetBool("Attack", true);
        }
    }

    private void Hit()
    {
        Collider2D[] hitGoblins = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, goblinLayers);
        for (int i = 0; i < hitGoblins.Length; i++)
        {
            hitGoblins[i].GetComponent<GoblinStats>().TakeDamage(stats.damage);
        }
        Collider2D[] hitGhosts = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ghostLayers);
        for (int i = 0; i < hitGhosts.Length; i++)
        {
            hitGhosts[i].GetComponent<GhostStats>().TakeDamage(stats.damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void BackToMove()
    {
        attacking = false;
        animator.SetBool("Attack", false);
    }

    private void setAnimation()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetInteger("Direction", direction);
    }

    private void takeInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        direction = setDirection(movement);
    }

    private int setDirection(Vector2 movement)
    {
        int direct = direction;
        if (movement.y == 1)
        {
            direct = 1;
        }
        else if (movement.x == 1)
        {
            direct = 2;
        }
        else if (movement.y == -1)
        {
            direct = 3;
        }
        else if (movement.x == -1)
        {
            direct = 4;
        }
        return direct;
    }
   
    private void Move()
    {
        rigid.MovePosition(rigid.position + movement * movementSpeed * Time.deltaTime);
    }
}

