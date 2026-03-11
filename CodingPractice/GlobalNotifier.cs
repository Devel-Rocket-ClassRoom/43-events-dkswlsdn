using System;
using System.Collections.Generic;
using System.Text;

public class GlobalNotifier
{
    public static event Action<string> OnGlobalMessage;

    public static void SendMessage(string message)
    {
        Console.WriteLine($"[Global] 메시지 전송: {message}");
        OnGlobalMessage?.Invoke(message);
    }
}

public class Module1
{
    public Module1()
    {
        GlobalNotifier.OnGlobalMessage += (msg) => Console.WriteLine($"[Module1] 수신: {msg}");
    }
}

public class Module2
{
    public Module2()
    {
        GlobalNotifier.OnGlobalMessage += (msg) => Console.WriteLine($"[Module2] 수신: {msg}");
    }
}