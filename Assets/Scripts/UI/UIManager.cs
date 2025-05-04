using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour, IInitialization
{
    [SerializeField] private GameObject _loseWindow;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private float _score;

    public void Init()
    {
        _score = 0;
        HideLoseWindow();
        ChangeScore();
        UIEventManager.OnShowLoseWindow += ShowLoseWindow;
        UIEventManager.OnAddScore += AddScore;
        UIEventManager.OnAddScore += ChangeScore;
    }

    private void ShowLoseWindow()
    {
        _loseWindow.SetActive(true);
        UIEventManager.OnShowLoseWindow -= ShowLoseWindow;
    }
    private void HideLoseWindow()
    {
        _loseWindow.SetActive(false);
    }

    private void AddScore()
    {
        _score++;
    }
    private void ChangeScore()
    {
        _scoreText.text = "Score: " + _score.ToString();
    }
}
