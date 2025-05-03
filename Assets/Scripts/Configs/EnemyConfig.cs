using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
public class EnemyConfig : AbstractConfig<EnemyConfig>
{
    [SerializeField] private float _hp;
    [SerializeField] private float _speed;
    [SerializeField] private float _radiusAttack;

    public float Hp => _hp;
    public float Speed => _speed;
    public float RadiusAttack => _radiusAttack;
}
