using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 FacingDirection { get; private set; }
    private bool _isMoving;
    public Animator animator;
    //public Rigidbody2D rb;

    public LayerMask _furnitureLayer;
    
    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        HandleInputs();
        animator.SetBool("_isMoving", _isMoving);
    }
    
        private void HandleInputs() {
            
            if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) {
                _isMoving = false;
                return;
            }

            _isMoving = true;
            Vector2 direction = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            
            );
            
            animator.SetFloat("Speed", moveSpeed);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Horizontal", FacingDirection.x);
            animator.SetFloat("Vertical", FacingDirection.y);
            if(direction.x != 0 && direction.y != 0) {
                direction.x = 0; // if you want to prioritize up/down movement, otherwise use .y
            }
            direction = direction.normalized * (moveSpeed * Time.deltaTime);
            transform.position += new Vector3(direction.x, direction.y, 0);
            FacingDirection = direction.normalized;
            _isMoving = true;
        }
    
    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.1f, _furnitureLayer) != null)
        {
            return false;
        }
        return true;
    }    

}

