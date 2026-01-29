using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text = null;
    [SerializeField] GameObject spowener = null;
    [SerializeField] RectTransform bossUI = null;
    private DateTime startTime;

    [SerializeField] bool isBoss = false;
    private void Start()
    {
        startTime = DateTime.Now;
    }

    IEnumerator CoBoss()
    {
        bossUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        bossUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        TimeSpan currentTime = DateTime.Now - startTime;
        text.text = $"{currentTime.Hours:00}:{currentTime.Minutes:00}:{currentTime.Seconds:00}";

        if (isBoss == false && $"{currentTime.Seconds:00}" == "58")
        {
            spowener.SetActive(false);
            isBoss = true;
            StartCoroutine(CoBoss());
        }
    }
}
