using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        GetHorizontalMvmt();
    }
    
    private void GetHorizontalMvmt()
    {
        if (Input.GetAxisRaw("Horizontal") != 0) MonkeyAnims.instance.SetRunning();
        else MonkeyAnims.instance.EndRunning();
        if (!MonkeyWallJump.IsTouchingWall() || MonkeyJump.GetIsGrounded())
        {
            if (MonkeyJump.GetIsGrounded())
            {
                _rigidbody2D.velocity =  
                    new Vector2(
                        Input.GetAxisRaw("Horizontal") * 1.5f * speed, 
                        _rigidbody2D.velocity.y
                    );
                return;
            }
            _rigidbody2D.velocity =  
                new Vector2(
                    Input.GetAxisRaw("Horizontal") * speed, 
                    _rigidbody2D.velocity.y
                );
        }
    }
}
