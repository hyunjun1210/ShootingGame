using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float speed = 3f;
    public Rigidbody2D Rigidbody => rigidbody;

    public float Speed => speed;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
}
