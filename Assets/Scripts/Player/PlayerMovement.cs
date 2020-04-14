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
    bool attacking = false;
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        if (attacking == false)
        {
            takeInput();
            setAnimation();
            Move();
            Attack();
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            attacking = true;
            animator.SetBool("Attack", true);
        }
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

