using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpownManager : MonoBehaviour
{
    #region Singleton
    private static ItemSpownManager instance = null;

    public static ItemSpownManager Instance => instance;

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


    public List<GameObject> items = new();

    public void ItemInstaniate(Vector3 vector)
    {
        int id = Random.Range(0, items.Count);
        var obj = Instantiate(items[id]);
        obj.transform.position = vector;
    }
}
