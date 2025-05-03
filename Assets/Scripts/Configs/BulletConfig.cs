using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "Configs/BulletConfig")]
public class BulletConfig : AbstractConfig<BulletConfig>
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    public float Damage => _damage;
    public float Speed => _speed;
    public float LifeTime => _lifeTime;

}
