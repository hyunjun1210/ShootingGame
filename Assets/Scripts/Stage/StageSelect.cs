using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [SerializeField] bool isStage1 = true;
    [SerializeField] GameObject left;
    [SerializeField] GameObject right;
    [SerializeField] Animator animator;

    const string LEFT_ANIMA_NAME = "Stage2";
    const string RIGHT_ANIMA_NAME = "Stage1";

    public void MoveLeft()
    {
        animator.SetTrigger(LEFT_ANIMA_NAME);
        isStage1 = true;
    }

    public void MoveRight()
    {
        animator.SetTrigger(RIGHT_ANIMA_NAME);
        isStage1 = false;
    }

    public void Select()
    {
        if (isStage1)
        {
            SceneManager.LoadScene("Stage1");
        }
        else
        {
            SceneManager.LoadScene("Stage2");
        }
    }

    private void Update()
    {
        left.SetActive(!isStage1);
        right.SetActive(isStage1);
    }
}
