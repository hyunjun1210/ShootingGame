using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject heart = null;
    [SerializeField] GameObject hearts = null;
    [SerializeField] GameObject gameOverUI = null;
    [SerializeField] Image fuel = null;
    [SerializeField] TextMeshProUGUI attackPower = null;
    [SerializeField] TextMeshProUGUI score = null;

    private void Start()
    {
        StartCoroutine(CoFuel());
        for (int i = 0; i < PlayerDataManager.Instance.hp; i++)
        {
            PlayerDataManager.Instance.playerHeart.Add(Instantiate(heart, hearts.transform));
        }
    }

    IEnumerator CoFuel()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            PlayerDataManager.Instance.fuel--;
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
        else if (ins.hp > ins.playerHeart.Count)
        {
            PlayerDataManager.Instance.playerHeart.Add(Instantiate(heart, hearts.transform));
        }    

        if (ins.hp <= 0 || ins.fuel <= 0)
        {
            ins.GameOver();
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }

        score.text = $"Score : {GameManager.Instance.score:000}";
        fuel.fillAmount = ins.fuel / ins.maxFuel;
        attackPower.text = "00" + PlayerDataManager.Instance.atkLevel;
    }
}
