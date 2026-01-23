using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipEnemy : MonoBehaviour
{
    [SerializeField] EnemyBullet bullet;
    [SerializeField] Transform pos;
    public int hp;
    public int maxHp;
    public int atkLevel;
    public int atkPower;

    private void Start()
    {
        StartCoroutine(CoAttack());
    }
    IEnumerator CoAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            EnemyBullet b = Instantiate(bullet);
            b.transform.position = pos.position;
            b.Rigidbody.velocity = Vector2.down * b.Speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            hp -= PlayerDataManager.Instance.atkPower;
            Destroy(collision.gameObject);
            StartCoroutine(CoDamage());
        }
    }

    IEnumerator CoDamage()
    {
        while (true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(.5f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.enemyCount--;
    }
}
