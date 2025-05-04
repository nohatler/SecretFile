using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IInitialization, IUnit
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private GameObject _spawnAttack;
    [SerializeField] private GameObject _bullet;

    private float _hp;
    private float _attackSpeed;
    private bool _canAttack;

    public void Init()
    {
        _hp = _playerConfig.Hp;
        _attackSpeed = _playerConfig.AttackSpeed;
        _canAttack = true;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        StartCoroutine(Attack());
    }

    public void HandleMovement()
    {
        if (!Touch())
            return;

        Vector3 touchPosition = Input.mousePosition;
        Ray ray = _mainCamera.ScreenPointToRay(touchPosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 target = hit.point;
            Vector3 lookDirection = target - transform.position;
            lookDirection.y = 0;

            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = targetRotation;
            }
        }
    }

    public IEnumerator Attack()
    {
        if (!Touch() || !_canAttack)
            yield break;

        _canAttack = false;

        Instantiate(_bullet, _spawnAttack.transform.position, _spawnAttack.transform.rotation);
        yield return new WaitForSeconds(_attackSpeed);

        _canAttack = true;
    }

    private bool Touch()
    {
        return Input.GetMouseButton(0) || Input.touchCount > 0;
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
            UIEventManager.SendShowLoseWindow();
            Destroy(gameObject);
        }
    }
}
