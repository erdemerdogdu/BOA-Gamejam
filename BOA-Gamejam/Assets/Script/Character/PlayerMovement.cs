using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    
    Vector2 movement;

    [Header("Blink Settings")] [SerializeField]
    public float blinkDistance;
    private float blinkTimer;
    public float blinkTime;
    bool facingRight;
    bool facingUp;
    public bool canBlink = true;

    void Blink()
    {
        Vector3 blink;
        if (facingRight)
        {
            blink = new Vector3(blinkDistance, 0, 0);
        }
        else
        {
            blink = new Vector3(-blinkDistance, 0, 0);
        }
        if (facingUp)
        {
            blink = new Vector3(0, blinkDistance, 0);
        }
        else
        {
            blink = new Vector3(0, -blinkDistance, 0);
        }
        if (facingUp && facingRight)
        {
            blink = new Vector3(blinkDistance, blinkDistance, 0);
        }
        else if(facingUp && !facingRight)
        {
            blink = new Vector3(-blinkDistance, blinkDistance, 0);
        } 
        else if(!facingUp && facingRight)
        {
            blink = new Vector3(blinkDistance, -blinkDistance, 0);
        }
        else if(!facingUp && !facingRight)
        {
            blink = new Vector3(-blinkDistance, -blinkDistance, 0);
        }

        transform.position += blink;
    }
    
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw(("Vertical"));
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && canBlink)
        {
            animator.SetBool("Blink", true);
            canBlink = false;
        }
        else
        {
            animator.SetBool("Blink", false);
        }

        if (!canBlink)
        {
            blinkTimer += Time.deltaTime;
        }

        if (blinkTimer > blinkTime)
        {
            canBlink = true;
            blinkTimer = 0;
        }
        
        if (movement.x >= 1)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }
        if (movement.y >= 1)
        {
            facingUp = true;
        }
        else
        {
            facingUp = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
