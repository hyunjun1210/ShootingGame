using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject heart = null;
    [SerializeField] GameObject hearts = null;
    [SerializeField] GameObject gameOverUI = null;

    private void Start()
    {
        for (int i = 0; i < PlayerDataManager.Instance.hp; i++)
        {
            PlayerDataManager.Instance.playerHeart.Add(Instantiate(heart, hearts.transform));
        }
    }

    public void SceneLoad()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }

    private void Update()
    {
        var ins = PlayerDataManager.Instance;
        if (ins.hp < ins.playerHeart.Count)
        {
            Destroy(ins.playerHeart[0].gameObject);
            ins.playerHeart.RemoveAt(0);
        }

        if (ins.hp <= 0)
        {
            ins.GameOver();
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
    }
}
