using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSkill : MonoBehaviour
{
    [SerializeField] Image image1 = null;
    [SerializeField] Image image2 = null;
    float kCount = 1;
    float lCount = 1;
    const float K_COUNT = 10;
    const float L_COUNT = 10;

    private void Start()
    {
        kCount = K_COUNT;
        lCount = L_COUNT;
    }

    private void Update()
    {
        lCount = Mathf.Min(lCount, L_COUNT);
        kCount = Mathf.Min(kCount, K_COUNT);
        if (Input.GetKeyDown(KeyCode.K) && kCount >= K_COUNT && PlayerDataManager.Instance.hp < PlayerDataManager.Instance.maxHp)
        {
            kCount = 1;
            PlayerDataManager.Instance.hp += 1;
        }
        else if (Input.GetKeyDown(KeyCode.L) && lCount >= L_COUNT)
        {
            lCount = 1;
            var enemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var e in enemy)
            {
                var spaceship = e.GetComponent<SpaceshipEnemy>();
                var meteorite = e.GetComponent<Meteorite>();
                //Todo : 보스 구현
                if (spaceship != null)
                {
                    spaceship.hp -= 1;
                    StartCoroutine(spaceship.CoDamage());
                }
                else if (meteorite != null)
                {
                    meteorite.hp -= 1;
                }
            }
        }

        if (kCount < K_COUNT)
        {
            kCount += Time.deltaTime;
        }
        if (lCount < L_COUNT)
        {
            lCount += Time.deltaTime;
        }

        image1.fillAmount = kCount / K_COUNT;
        image2.fillAmount = lCount / L_COUNT;
    }
}
