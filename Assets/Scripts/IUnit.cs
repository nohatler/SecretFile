using System.Collections;

public interface IUnit
{
    public IEnumerator Attack();
    public void Death();
    public void TakeDamage(float damage);
    public void HandleMovement();
}
