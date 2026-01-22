using System;
using UnityEngine;

public class BackgroundSize : MonoBehaviour
{
    private SpriteRenderer spriteRenderer = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        float spriteX = spriteRenderer.sprite.bounds.size.x;
        float spriteY = spriteRenderer.sprite.bounds.size.y;

        float screenY = Camera.main.orthographicSize * 2;
        float screenX = screenY / Screen.height * Screen.width;

        transform.localScale = new Vector3(Mathf.Ceil(screenX / spriteX), Mathf.Ceil(screenY / spriteY));
    }
}