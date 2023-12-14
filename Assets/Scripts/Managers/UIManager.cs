using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Image _healthBarBG;
    [SerializeField] private Image _healthBar;
    [SerializeField] private TMP_Text _totalCoinsText;
    [SerializeField] private TMP_Text _killCountText;

    [SerializeField] private GameObject _failWindow;

    private Camera _camera;

    private float _currentPlayerHealthPercentage = 1;

    private float _healthBarChangeSpeed = 0.1f;

    private void Awake()
    {
        GameManager.OnPlayerHealthPercentageChanged += OnPlayerHealthChanged;
        GameManager.OnKillCountChanged += OnKillCountChanged;
        GameManager.OnTotalCoinsChanged += OnTotalCoinsChanged;
        GameManager.OnGameStateChanged += OnGameStateChanged;
        _camera = Camera.main;
    }



    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.Fail)
        {
            _failWindow.SetActive(true);
        }
    }

    private void Update()
    {
        Vector3 PlayerPosInScreenSpace = _camera.WorldToScreenPoint(UnitManager.Instance.Player.transform.position);
        _healthBarBG.transform.position = PlayerPosInScreenSpace + Vector3.up * 80;

        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, _currentPlayerHealthPercentage, 0.2f);
    }

    private void OnPlayerHealthChanged(float health)
    {
        _currentPlayerHealthPercentage = health;
    }

    private void OnTotalCoinsChanged(int totalCoins)
    {
        _totalCoinsText.text = totalCoins.ToString();
    }
    private void OnKillCountChanged(int killCount)
    {
        _killCountText.text = killCount.ToString();
    }

    public void OnRestartClicked()
    {
        GameManager.Instance.Restart();
    }
}
