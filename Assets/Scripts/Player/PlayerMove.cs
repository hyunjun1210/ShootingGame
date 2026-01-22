using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rigidbody = null;
    private Animator animator = null;
    private const string HORIZONTAL_NAME = "Horizontal";

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Move()
    {
        float xInput = Input.GetAxis(HORIZONTAL_NAME);
        float yInput = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector2(xInput, yInput) * speed;

        float maxY = Camera.main.orthographicSize;
        float maxX = maxY * Camera.main.aspect;

        float x = Mathf.Clamp(transform.position.x, -maxX, maxX);
        float y = Mathf.Clamp(transform.position.y, -maxY, maxY);

        transform.position = new Vector2(x, y);
    }

    private void MoveAnimation()
    {
        animator.SetFloat(HORIZONTAL_NAME, Input.GetAxisRaw(HORIZONTAL_NAME));
    }

    void Update()
    {
        Move();
        MoveAnimation();
    }
}