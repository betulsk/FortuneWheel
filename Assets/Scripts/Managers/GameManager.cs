using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _level = 1;

    public int CurrentLevel
    {
        get { return _level; }
        set { _level = value; }
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {

    }
}
