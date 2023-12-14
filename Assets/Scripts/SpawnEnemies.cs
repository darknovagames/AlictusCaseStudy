using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    private Player _player;

    [SerializeField] private float _spawnCooldown = 1;

    private Camera _camera;

    [SerializeField] private Enemy _enemyPrefab;

    [SerializeField] private float _enemyRadius = 1;

    private float _lastSpawnTime = -999;

    private void Start()
    {
        _player = UnitManager.Instance.Player;
        _camera = Camera.main;
    }

    private void Update()
    {
        if(Time.time > _lastSpawnTime + _spawnCooldown)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Plane[] CameraFrustumPlanes = GeometryUtility.CalculateFrustumPlanes(_camera);

        Ray ray = new Ray(_player.transform.position, Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * Vector3.right);

        float distanceToTheEdge;
        float closestDistanceToTheEdge = 500;

        for (int i = 0; i < 4; i++)
        {
            if (CameraFrustumPlanes[i].Raycast(ray, out distanceToTheEdge))
            {
                closestDistanceToTheEdge = Mathf.Min(closestDistanceToTheEdge, distanceToTheEdge);
            }
        }

        Vector3 spawnPoint = ray.GetPoint(closestDistanceToTheEdge + _enemyRadius);

        Vector3 playersDir = _player.transform.position - spawnPoint;

        Instantiate(_enemyPrefab, spawnPoint, Quaternion.LookRotation(playersDir,Vector3.up));

        _lastSpawnTime = Time.time;
    }
}
