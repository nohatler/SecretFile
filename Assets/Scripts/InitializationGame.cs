using System.Collections.Generic;
using UnityEngine;

public class InitializationGame : MonoBehaviour
{
    [SerializeField] private Player _playerController;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private UIManager _uiManager;

    private void Start()
    {
        Application.targetFrameRate = 60;
        _playerController.Init();
        _uiManager.Init();
        _spawner.Init();
    }
}
