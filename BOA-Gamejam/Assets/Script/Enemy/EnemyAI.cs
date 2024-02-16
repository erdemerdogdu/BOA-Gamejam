using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float checkRad;
    public float atttackRad;

    public bool shouldRotate;


    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;

    }

    private void Update ()
    {
        anim.SetBool("isRunnig", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRad, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, atttackRad, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (shouldRotate)
        {
            anim.SetFloat("x", dir.x);
            anim.SetFloat("y", dir.y);
        }
    }

    private void FixedUpdate()
    {
        if (isInAttackRange && isInChaseRange)
        {
            MoveCharacter(movement);
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

}
