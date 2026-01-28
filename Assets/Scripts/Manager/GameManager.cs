using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance = null;

    public static GameManager Instance => instance;

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

    public bool isStageLocked = true;

    public int enemyCount = 0;

    public bool isInvincible = false;

    public void Invisible()
    {
        StartCoroutine(CoInvincible());
    }

    IEnumerator CoInvincible()
    {
        isInvincible = true;
        yield return new WaitForSecondsRealtime(1.5f);
        isInvincible = false;
    }
}
