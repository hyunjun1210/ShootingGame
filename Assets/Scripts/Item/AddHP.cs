using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHP : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody = null;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float rotateSpeed = 6f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.score++;
            PlayerDataManager.Instance.hp += 1;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        float maxY = Camera.main.orthographicSize;
        if (transform.position.y < -maxY)
        {
            Destroy(gameObject);
        }
        rigidbody.velocity = Vector2.down * speed;
        transform.Rotate(Vector3.forward * rotateSpeed);
    }
}
