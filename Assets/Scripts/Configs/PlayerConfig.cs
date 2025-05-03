using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : AbstractConfig<PlayerConfig>
{
    [SerializeField] private float _hp;
    [SerializeField] private float _attackSpeed;

    public float Hp => _hp;
    public float AttackSpeed => _attackSpeed;
}
