using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerConfig", menuName = "Configs/SpawnerConfig")]
public class SpawnerConfig : AbstractConfig<SpawnerConfig>
{
    [SerializeField] private float _maxSpawnInterval;
    [SerializeField] private List<GameObject> _enemyList;

    public float MaxSpawnInterval => _maxSpawnInterval;
    public List<GameObject> EnemyList => _enemyList;
}
