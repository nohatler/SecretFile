using System.Collections.Generic;
using UnityEngine;

public class InitializationGame : MonoBehaviour
{
    [SerializeField] private Player _playerController;
    [SerializeField] private List<Spawner> _spawners;

    private void Start()
    {
        _playerController.Init();

        foreach(var spawner in _spawners)
        {
            spawner.Init();
        }
    }
}
