using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private BulletConfig _bulletConfig;

    private float _damage;
    private float _speed;
    private float _lifeTime;

    private void Start()
    {
        _damage = _bulletConfig.Damage;
        _speed = _bulletConfig.Speed;
        _lifeTime = _bulletConfig.LifeTime;
        StartCoroutine(DestroyBulletIfLeftTime());
    }

    private void FixedUpdate()
    {
        _rb.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private IEnumerator DestroyBulletIfLeftTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(_lifeTime);
            DestroyBullet();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.CompareTag("Enemy") || hit.CompareTag("Player"))
        {
            hit.GetComponent<IUnit>().TakeDamage(_damage);
            DestroyBullet();
        }
    }
}
