using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerConfig", menuName = "Configs/SpawnerConfig")]
public class SpawnerConfig : AbstractConfig<SpawnerConfig>
{
    [SerializeField] private float _spawnInterval;
    [SerializeField] private List<GameObject> _enemyList;

    public float SpawnInterval => _spawnInterval;
    public List<GameObject> EnemyList => _enemyList;
}
