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
    public int atkLevel = 1;
    public int atkPower;
    public float fuel;
    public float maxFuel = 100;

    public List<GameObject> playerHeart = new List<GameObject>();

    public void GameOver()
    {
        playerHeart.Clear();
        hp = maxHp;
        atkPower = 1;
        atkLevel = 1;
        fuel = maxFuel;
    }

    private void Update()
    {
        hp = Mathf.Clamp(hp, 0, maxHp);
        fuel = Mathf.Clamp(fuel, 0, maxFuel);
        atkLevel = Mathf.Clamp(atkLevel, 1, 4);
        atkPower = atkLevel;
    }
}
