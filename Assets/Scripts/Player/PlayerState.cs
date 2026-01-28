using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] GameObject obj;

    private void Update()
    {
        obj.SetActive(GameManager.Instance.isInvincible);
    }
}
