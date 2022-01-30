using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Transform _camera;

    public float xOffset = 2.0f, yOffset = 2.0f;

    private void Awake()
    {
        _camera = transform;
    }

    private void FixedUpdate()
    {
        Vector3 camPos = _camera.position, playerPos = player.position;
        
        if (playerPos.x - camPos.x > xOffset)
        {
            camPos.x = playerPos.x - xOffset;
        }
        else if (playerPos.x - camPos.x < -xOffset)
        {
            camPos.x = playerPos.x + xOffset;
        }

        if (playerPos.y - camPos.y > xOffset)
        {
            camPos.y = playerPos.y - xOffset;
        }
        else if (playerPos.y - camPos.y < -xOffset)
        {
            camPos.y = playerPos.y + xOffset;
        }

        this.transform.position = camPos;
    }
}
