using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {

        }
        else
        {
            _instance = this;
        }
    }

    #endregion


    public List<GameObject> EnemyList;
    public GameObject Player;
    public int FailedEnemy;
    public bool GameWin;
    public bool GameOver;

}
