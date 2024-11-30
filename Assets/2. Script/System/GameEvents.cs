using System;

public static class GameEvents
{
    public static InputFieldEvent InputFieldEvent = new();
    public static GameStartTimeEvent GameStartTimeEvent = new();
    public static GameCurrentTimeEvent GameCurrentTimeEvent = new();
    public static ShowPlayTimeAndSceneNameEvent ShowPlayTimeAndSceneNameEvent = new();
    public static EnemySpawnEvent EnemySpawnEvent = new();
}

public class InputFieldEvent : GameEvent
{
    public string Text;
}

public class SearchEvent : GameEvent
{

}

public class GameStartTimeEvent : GameEvent
{
    public DateTime StartTime;
}

public class GameCurrentTimeEvent : GameEvent
{
    public DateTime CurrentTime;
    public float PlayTime;
}

public class ShowPlayTimeAndSceneNameEvent : GameEvent
{    
}

public class EnemySpawnEvent : GameEvent
{
    public int EnemyCount;
}