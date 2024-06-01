using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool isMoving;
    public Rigidbody2D rb;
    public Animator animator;
 
    Vector2 movement;
    
    // Update is called once per frame
    private void Update()
    {
        if (!isMoving)
        {
            movement.x = Input.GetAxisRaw("Horizontal"); 
            movement.y = Input.GetAxisRaw("Vertical");
            
            if (movement.x != 0) movement.y = 0;
            
            if (movement != Vector2.zero)
            {
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
                isMoving = true;
                
                var targetPos = transform.position;
                targetPos.x += movement.x;
                targetPos.y += movement.y;
                
                StartCoroutine(Move(targetPos));
            }
        }
        
    }

    /*private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }*/
    
    
    IEnumerator Move(Vector3 targetPos)
    {
        while ((targetPos - transform.position).sqrMagnitude > float.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
