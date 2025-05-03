using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, Initialization
{
    [SerializeField] private SpawnerConfig _spawnerConfig;
    [SerializeField] private GameObject _player;
    private float _maxSpawnInterval;
    private List<GameObject> _enemyList;

    public void Init()
    {
        _maxSpawnInterval = _spawnerConfig.MaxSpawnInterval;
        _enemyList = _spawnerConfig.EnemyList;
        StartCoroutine(SpawnerEnemy());
    }

    private void Spawn()
    {
        GameObject enemy = Instantiate(_enemyList[Random.Range(0, _enemyList.Count)]);
        enemy.transform.position = transform.position;
        Enemy enemyScript = enemy.GetComponent<Enemy>();

        enemyScript.SetTarget(_player);
        enemyScript.SetHp(enemyScript.EnemyConfig.Hp);
        enemyScript.SetSpeed(enemyScript.EnemyConfig.Speed);
        enemyScript.SetRadius(enemyScript.EnemyConfig.RadiusAttack);
    }


    private IEnumerator SpawnerEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(8f, _maxSpawnInterval));
            Spawn();
        }
    }
}
