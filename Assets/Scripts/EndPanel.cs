using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanel : MonoBehaviour
{

    public GameObject LevelCompleted;


    public GameObject LevelFailed;

    // CANVAS EKRANI İÇİN

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (GameManager.Instance.GameOver)
        {
            LevelFailed.SetActive(true);
            
        }

        if (GameManager.Instance.GameWin)
        {
            LevelCompleted.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
