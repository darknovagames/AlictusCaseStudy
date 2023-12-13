using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public static event Action<GameState> OnGameStateChanged;
    public static event Action<int> OnEnemyDeathsChanged;

    public GameState state { get; private set; }

    public void ChangeGameState(GameState gameState)
    {
        state = gameState;
        if(gameState == GameState.Fail)
        {
            
        }
    }
}

[Serializable]
public enum GameState
{
    InGame = 0,
    Fail = 1
}