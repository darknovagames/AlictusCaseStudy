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

    private Camera _camera;

    private void Start()
    {
        GameController.OnPlayerHealthPercentageChanged += OnPlayerHealthChanged;
        GameController.OnKillCountChanged += OnKillCountChanged;
        GameController.OnTotalCoinsChanged += OnTotalCoinsChanged;
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 PlayerPosInScreenSpace = _camera.WorldToScreenPoint(UnitManager.Instance.Player.transform.position);
        _healthBarBG.transform.position = PlayerPosInScreenSpace + Vector3.up * 80;
    }

    private void OnPlayerHealthChanged(float health)
    {
        _healthBar.fillAmount = health;
    }

    private void OnTotalCoinsChanged(int totalCoins)
    {
        _totalCoinsText.text = totalCoins.ToString();
    }
    private void OnKillCountChanged(int killCount)
    {
        _killCountText.text = killCount.ToString();
    }

}
