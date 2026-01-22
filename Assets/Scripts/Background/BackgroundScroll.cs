using System;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    private SpriteRenderer spriteRenderer = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Scroll()
    {
        float y = (Time.time * speed) % 1f;
        spriteRenderer.material.mainTextureOffset = new Vector2(0, y);
    }

    private void Update()
    {
        Scroll();
    }
}