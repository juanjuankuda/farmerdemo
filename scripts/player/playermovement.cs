using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D rb;
    SpriteRenderer sp;
    Vector2 moveDir;
    float lastHorizontal;
    float lastVertical;
    public bool isFacingLeft = false;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        facing(lastHorizontal);
    }

    void inputManager()
    {
        if (canMove)
        {
            float movex = Input.GetAxisRaw("Horizontal");
            float movey = Input.GetAxisRaw("Vertical");
            moveDir = new Vector2(movex, movey).normalized;
            if (movex != 0)
            {
                lastHorizontal = movex;
            }
            if (movey != 0)
            {
                lastVertical = movey;
            }
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * movespeed, moveDir.y * movespeed);
    }

    void facing(float movedirection_x)
    {
        if (movedirection_x < 0)
        {
            sp.flipX = true;
            isFacingLeft = true;
        }
        else
        {
            sp.flipX = false;
            isFacingLeft = false;
        }
    }
}