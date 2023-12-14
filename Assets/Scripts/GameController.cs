using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public static event Action<GameState> OnGameStateChanged;
    public static event Action<int> OnEnemyDeathsChanged;
    public static event Action<float> OnPlayerHealthPercentageChanged;
    public static event Action<int> OnTotalCoinsChanged;
    public static event Action<int> OnKillCountChanged;

    private int _totalCoins = 0;
    private int _killCount = 0;

    public GameState state { get; private set; }

    public void ChangeGameState(GameState gameState)
    {
        state = gameState;
    }

    public void IncreaseKillCount()
    {
        _killCount++;
        OnKillCountChanged.Invoke(_killCount);
    }

    public void IncreaseTotalCoins()
    {
        _totalCoins++;
        OnTotalCoinsChanged.Invoke(_totalCoins);
    }

    public void PlayerHealthPercentageChanged(float amount)
    {
        OnPlayerHealthPercentageChanged.Invoke(amount);
        if(amount <= 0 && state == GameState.InGame)
        {
            ChangeGameState(GameState.Fail);
        }
    }

}

[Serializable]
public enum GameState
{
    InGame = 0,
    Fail = 1
}