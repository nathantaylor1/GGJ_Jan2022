using System;
using UnityEngine;

public class MonkeyJump : MonoBehaviour
{
    private static bool _isGrounded;

    public static bool GetIsGrounded()
    {
        return _isGrounded;
    }
    
    public float distanceBelow;
    public LayerMask groundLayer;
    public float jumpForce;
    
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }
    
    private void Update()
    {
        _isGrounded = Physics2D.OverlapBox(
            new Vector2(transform.position.x, transform.position.y - distanceBelow), 
            new Vector2(0.6f, 0.2f), 0f, groundLayer);

        if (!_isGrounded) return;
        
        MonkeyAnims.instance.EndJumping();
        if (Input.GetAxisRaw("Jump") == 0) return;
            
        MonkeyAnims.instance.SetJumping();
        _rigidbody2D.velocity = Vector2.up * jumpForce * Input.GetAxis("Jump");
    }

    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - distanceBelow),
            new Vector2(0.6f, 0.2f));
    }
    */
}
