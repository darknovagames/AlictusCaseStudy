using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health;
    public float MaxHealth = 100;

    private void Start()
    {
        Health = MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameController.Instance.IncreaseTotalCoins();
        }

        if (other.gameObject.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
            Health -= 20;
            PlayerHealthUpdated();
        }
        
        if (other.gameObject.tag == "Enemy")
        {
            Health = 0;
            PlayerHealthUpdated();
        }
    }

    private void PlayerHealthUpdated()
    {
        GameController.Instance.PlayerHealthPercentageChanged(Health / MaxHealth);
    }
}
