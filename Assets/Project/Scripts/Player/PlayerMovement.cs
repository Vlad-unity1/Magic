using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 720f;

    internal void Move(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x, 0, direction.y) * _speed * Time.deltaTime;

        if (movement != Vector3.zero)
        {
            transform.position += movement;
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
