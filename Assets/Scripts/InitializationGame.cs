using UnityEngine;

public class InitializationGame : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _playerController.Init();
    }
}
