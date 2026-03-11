using System;

ScoreSystem scoreSystem = new ScoreSystem();
AchievementSystem achievementSystem = new AchievementSystem();
SoundSystem soundSystem = new SoundSystem();

EventManager.OnGameEvent += soundSystem.Sound;
EventManager.OnGameEvent += scoreSystem.ScoreChanged;
EventManager.OnGameEvent += achievementSystem.Achievement;

EventManager.TriggerEvent("ScoreChanged", 100);
EventManager.TriggerEvent("Achievement", "첫 번째 적 처치");
EventManager.TriggerEvent("GameOver", null);