using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerBullet bullet;
    [SerializeField] bool isAttack = false;
    void Start()
    {
        StartCoroutine(CoAttack());
    }

    IEnumerator CoAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            isAttack = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayerBullet b = Instantiate(bullet);
            b.transform.position = transform.position;
            b.Rigidbody.velocity = Vector2.up * b.Speed;
            isAttack = true;
        }
    }
}
