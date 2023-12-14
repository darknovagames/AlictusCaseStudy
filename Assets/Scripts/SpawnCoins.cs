using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private int _coinAmount = 100;
    [SerializeField] private float _spawnAreaSqr = 75;
    [SerializeField] private Transform _coinHolder;
    void Start()
    {
        for(int i = 0; i < _coinAmount; i++)
        {
            Instantiate(_coinPrefab, new Vector3(Random.Range(-_spawnAreaSqr / 2, -_spawnAreaSqr / 2), 1.7f, 
                        Random.Range(-_spawnAreaSqr / 2, -_spawnAreaSqr / 2)), 
                        Quaternion.identity, 
                        _coinHolder);
        }
    }

}
