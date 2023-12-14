using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health;
    public float MaxHealth = 100;

    public bool IsDead = false;

    private void Start()
    {
        Health = MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameManager.Instance.IncreaseTotalCoins();
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
        if (Health <= 0)
        {
            IsDead = true;
            GameManager.Instance.ChangeGameState(GameState.Fail);
        }

        GameManager.Instance.PlayerHealthPercentageChanged(Health / MaxHealth);
    }
}
