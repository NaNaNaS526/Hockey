using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private bool _isMovingRight;
    public float moveSpeed = 1f;

    private void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        if (_rigidBody.position.x <= -0.55 | _rigidBody.position.x >= 0.55)
        {
            CheckDirection();
        }
    }

    private void Move()
    {
        if (_isMovingRight)
        {
            _rigidBody.velocity = new Vector3(1f, 0f, 0f) * moveSpeed;
        }
        else
        {
            _rigidBody.velocity = new Vector3(-1f, 0f, 0f) * moveSpeed;
        }
    }

    private void CheckDirection()
    {
        if (_rigidBody.position.x <= -0.55 & _isMovingRight == false)
        {
            _isMovingRight = true;
        }

        else if (_rigidBody.position.x >= 0.55 & _isMovingRight)
        {
            _isMovingRight = false;
        }
    }
}