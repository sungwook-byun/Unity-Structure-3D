using System;
using UnityEngine;

public static class StudyEventBus
{
    public static event Action OnStart;
    public static event Action<int> onScoreChanged;

    public static void StartEvent()
    {
        OnStart?.Invoke();
    }

    public static void ScoreChanged(int newScore)
    {
        onScoreChanged?.Invoke(newScore);
    }
}
