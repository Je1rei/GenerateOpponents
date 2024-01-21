using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private Target[] _targets;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private float _delay;
    [SerializeField] private int _countSpawn;

    private void Start()
    {
        StartCoroutine(SpawnOpponents());
    }

    private IEnumerator SpawnOpponents()
    {
        var wait = new WaitForSeconds(_delay);

        for (int i = 0; i < _countSpawn; i++)
        {
            if (_enemyPrefabs.Length > 0)
            {
                Spawn(i % _enemyPrefabs.Length);
            }

            yield return wait;
        }
    }

    private void Spawn(int enemyIndex)
    {
        Enemy newEnemy = Instantiate(_enemyPrefabs[enemyIndex], _spawnPoints[enemyIndex].transform.position, Quaternion.identity);
        newEnemy.SetTarget(_targets[enemyIndex]);
    }
}
