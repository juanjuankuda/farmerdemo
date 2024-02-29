using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public Transform player;  
    public float moveSpeed = 2.0f; 
    public float stopDistance = 2.0f; 
    public Animator animator; 

    private Rigidbody2D rb;
    private bool isPlayingStopAnimation = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= stopDistance)
            {
                rb.velocity = Vector2.zero;
                animator.SetBool("StopAnimation", true);
                isPlayingStopAnimation = true;
            }
            else if (isPlayingStopAnimation)
            {
                animator.SetBool("StopAnimation", false);
                isPlayingStopAnimation = false;
            }
            else
            {
                rb.velocity = direction * moveSpeed;
                if (direction.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (direction.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
}
