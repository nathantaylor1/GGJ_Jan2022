using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyWallJump : MonoBehaviour
{
    private bool _wallJumping;
    private static bool _isTouchingLeft, _isTouchingRight;
    public float distanceForward;
    public LayerMask groundLayer;
    public float jumpForceY;
    public float jumpForceX;
    private float _touchingLeftOrRight;
    
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        _isTouchingLeft = Physics2D.OverlapBox(
            new Vector2(transform.position.x - distanceForward, transform.position.y), 
            new Vector2(0.2f, 0.6f), 0f, groundLayer);
        _isTouchingRight = Physics2D.OverlapBox(
            new Vector2(transform.position.x + distanceForward, transform.position.y), 
            new Vector2(0.2f, 0.6f), 0f, groundLayer);

        if (_isTouchingLeft)
        {
            print("left");
            _touchingLeftOrRight = 1;
        }

        if (_isTouchingRight)
        {
            print("right");
            _touchingLeftOrRight = -1;
        }

        if (Input.GetAxisRaw("Jump") != 0 && (_isTouchingLeft || _isTouchingRight) && !MonkeyJump.GetIsGrounded())
        {
            _wallJumping = true;
            Invoke("SetJumpingFalse", 0.08f);
        }

        if (_wallJumping)
        {
            MonkeyAnims.instance.SetJumping();
            _rigidbody2D.velocity = new Vector2(jumpForceX * _touchingLeftOrRight, jumpForceY);
        }
    }

    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x - distanceForward, transform.position.y), 
            new Vector2(0.2f, 0.6f));
        
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x + distanceForward, transform.position.y), 
            new Vector2(0.2f, 0.6f));
    }
    */

    private void SetJumpingFalse()
    {
        _wallJumping = false;
    }

    public static bool IsTouchingWall()
    {
        return (_isTouchingLeft || _isTouchingRight);
    }
}
