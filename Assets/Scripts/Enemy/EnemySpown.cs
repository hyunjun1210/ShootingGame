using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpown : MonoBehaviour
{
    [SerializeField] List<GameObject> enemy;
    [SerializeField] List<int> pos;

    private void Update()
    {
        if (GameManager.Instance.enemyCount <= 0)
        {
            pos.Clear();
            int count = Random.Range(0, 5);
            for (int i = 0; i < count; i++)
            {
                float maxY = Camera.main.orthographicSize;
                float maxX = maxY * Camera.main.aspect;
                bool hasPos = false;
                int rand = 0;
                do
                {
                    rand = Random.Range(-3, 4);
                    hasPos = pos.Any(x => x == rand);
                }
                while (hasPos);
                pos.Add(rand);
                int enemyCount = Random.Range(0, enemy.Count);
                var obj = Instantiate(enemy[enemyCount]);
                obj.transform.position = new Vector3(pos[i], 5.6f);
                GameManager.Instance.enemyCount++;
            }
        }
    }

}
