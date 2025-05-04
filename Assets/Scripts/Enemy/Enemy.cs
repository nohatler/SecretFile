using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IUnit
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _player;
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _spawnAttack;
    private float _hp;
    private float _speed;
    private float _radiusAttack;
    private bool _canAttack;

    private void Start()
    {
        _canAttack = true;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        StartCoroutine(Attack());
    }

    public void HandleMovement()
    {
        if (!_canAttack)
            return;

        Transform _target = _player.transform;
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.forward = direction;
        _rb.velocity = transform.forward * _speed;
    }

    public IEnumerator Attack()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= _radiusAttack && _canAttack)
        {
            _canAttack = false;

            yield return new WaitForSeconds(2f);
            Instantiate(_bullet, _spawnAttack.transform.position, _spawnAttack.transform.rotation);

            _canAttack = true;
        }
    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;
        Death();
    }

    public void Death()
    {
        if (_hp <= 0)
        {
            UIEventManager.SendAddScore();
            Destroy(gameObject);
        }
    }

    #region Get/Set
    public EnemyConfig EnemyConfig => _enemyConfig;
    public void SetTarget(GameObject player)
    {
        _player = player;
    }
    public void SetHp(float hp)
    {
        _hp = hp;
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    public void SetRadius(float radiusAttack)
    {
        _radiusAttack = radiusAttack;
    }
    #endregion
}
