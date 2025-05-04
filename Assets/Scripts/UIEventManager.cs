using System;
using UnityEngine;

public class UIEventManager : MonoBehaviour
{
    #region Lose

    public static Action OnShowLoseWindow;
    public static void SendShowLoseWindow()
    {
        if (OnShowLoseWindow != null) OnShowLoseWindow.Invoke();
    }

    public static Action OnRestartActivated;
    public static void SendRestartActivated()
    {
        if (OnRestartActivated != null) OnRestartActivated.Invoke();
    }

    #endregion

    #region Scores

    public static Action OnAddScore;
    public static void SendAddScore()
    {
        if (OnAddScore != null) OnAddScore.Invoke();
    }

    #endregion
}
