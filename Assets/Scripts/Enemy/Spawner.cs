using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IInitialization
{
    [SerializeField] private SpawnerConfig _spawnerConfig;
    [SerializeField] private GameObject _player;
    [SerializeField] private List<Transform> _spawnersList;
    private float _spawnInterval;
    private List<GameObject> _enemyList;

    public void Init()
    {
        _spawnInterval = _spawnerConfig.SpawnInterval;
        _enemyList = _spawnerConfig.EnemyList;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(2f, _spawnInterval));
            Transform spawner = _spawnersList[Random.Range(0, _spawnersList.Count)];

            GameObject enemy = Instantiate(_enemyList[Random.Range(0, _enemyList.Count)]);
            enemy.transform.position = spawner.position;
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            enemyScript.SetTarget(_player);
            enemyScript.SetHp(enemyScript.EnemyConfig.Hp);
            enemyScript.SetSpeed(enemyScript.EnemyConfig.Speed);
            enemyScript.SetRadius(enemyScript.EnemyConfig.RadiusAttack);
        }
    }
}
