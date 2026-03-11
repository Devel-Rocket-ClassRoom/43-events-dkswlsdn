using System;
using System.Collections.Generic;
using System.Text;

public class GameEventArgs : EventArgs
{
    public string EventName;
    public object Data;

    public GameEventArgs(string eventName, object data)
    {
        EventName = eventName; Data = data; 
    }
}

public static class EventManager
{
    public static event EventHandler<GameEventArgs> OnGameEvent;

    public static void TriggerEvent(string eventName, object data = null)
    {
        OnGameEvent?.Invoke(eventName, new GameEventArgs(eventName, data));
    }
}

public class ScoreSystem
{
    public void ScoreChanged(object eventName, GameEventArgs args)
    {
        if (eventName.Equals("ScoreChanged"))
        {
            Console.WriteLine($"점수 변경: {args.Data}");
        }
    }
}

public class AchievementSystem
{
    public void Achievement(object eventName, GameEventArgs args)
    {
        if (eventName.Equals("Achievement"))
        {
            Console.WriteLine($"업적 달성: {args.Data}");
        }
    }
}

public class SoundSystem
{
    public void Sound(object eventName, GameEventArgs args)
    {
        Console.WriteLine($"[Sound] 이벤트: {eventName}");
    }
}