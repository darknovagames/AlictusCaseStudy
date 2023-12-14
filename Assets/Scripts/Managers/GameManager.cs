using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static event Action<GameState> OnGameStateChanged;
    public static event Action<int> OnEnemyDeathsChanged;
    public static event Action<float> OnPlayerHealthPercentageChanged;
    public static event Action<int> OnTotalCoinsChanged;
    public static event Action<int> OnKillCountChanged;

    private int _totalCoins;
    private int _killCount;

    public GameState state { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (PlayerPrefs.HasKey("Coins"))
        {
            _totalCoins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            PlayerPrefs.SetInt("Coins", 0);
        }

        if (PlayerPrefs.HasKey("KillCount"))
        {
            _killCount = PlayerPrefs.GetInt("KillCount");
        }
        else
        {
            PlayerPrefs.SetInt("KillCount", 0);
        }
    }

    private void Start()
    {
        OnKillCountChanged.Invoke(_killCount);
        OnTotalCoinsChanged.Invoke(_totalCoins);
    }

    public void ChangeGameState(GameState gameState)
    {
        state = gameState;
        OnGameStateChanged.Invoke(gameState);
    }

    public void IncreaseKillCount()
    {
        _killCount++;
        OnKillCountChanged.Invoke(_killCount);
        UpdatePlayerPrefs();
    }

    public void IncreaseTotalCoins()
    {
        _totalCoins++;
        OnTotalCoinsChanged.Invoke(_totalCoins);
        UpdatePlayerPrefs();
    }

    public void PlayerHealthPercentageChanged(float amount)
    {
        OnPlayerHealthPercentageChanged.Invoke(amount);
        if(amount <= 0 && state == GameState.InGame)
        {
            ChangeGameState(GameState.Fail);
        }
    }

    private void UpdatePlayerPrefs()
    {
        PlayerPrefs.SetInt("Coins", _totalCoins);
        PlayerPrefs.SetInt("KillCount", _killCount);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

[Serializable]
public enum GameState
{
    InGame = 0,
    Fail = 1
}