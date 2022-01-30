using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    private static bool _facingRight = true;

    private void FixedUpdate()
    {
        HorizontalDirection();
    }
    
    private void HorizontalDirection()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        if (_facingRight && horizontalAxis < 0)
        {
            _facingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (!_facingRight && horizontalAxis > 0)
        {
            _facingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public static bool IsFacingRight()
    {
        return _facingRight;
    }
}
