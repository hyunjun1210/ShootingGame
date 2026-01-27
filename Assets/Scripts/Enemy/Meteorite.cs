using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody = null;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float rotateSpeed = 6f;
    [SerializeField] private float hp;
    [SerializeField] private float maxHp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerDataManager.Instance.hp -= 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            hp -= PlayerDataManager.Instance.atkPower;
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        float maxY = Camera.main.orthographicSize;
        if (transform.position.y < -maxY || hp <= 0)
        {
            ItemSpownManager.Instance.ItemInstaniate(transform.position);
            Destroy(gameObject);
        }
        rigidbody.velocity = Vector2.down * speed;
        transform.Rotate(Vector3.forward * rotateSpeed);
    }

    private void OnDestroy()
    {
        GameManager.Instance.enemyCount--;
    }
}
