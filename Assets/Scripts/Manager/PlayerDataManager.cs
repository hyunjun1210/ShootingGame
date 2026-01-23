using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    #region Singleton
    private static PlayerDataManager instance = null;

    public static PlayerDataManager Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public int hp;
    public int maxHp;
    public int atkLevel;
    public int atkPower;

    public List<GameObject> playerHeart = new List<GameObject>();

    public void GameOver()
    {
        playerHeart.Clear();
        hp = maxHp;
        atkPower = 1;
        atkLevel = 1;
    }

    private void Update()
    {
        hp = Mathf.Clamp(hp, 0, maxHp);
    }
}
