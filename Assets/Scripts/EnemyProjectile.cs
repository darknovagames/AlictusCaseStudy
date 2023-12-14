using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float Duration = 10;
    public float Speed = 8;

    private void Start()
    {
        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
        playerPos.y = transform.position.y;

        transform.LookAt(playerPos);
    }

    private void Update()
    {
        Duration -= Time.deltaTime;
        if (Duration < 0) Destroy(gameObject);

        transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
    }
}
