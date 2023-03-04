public static class Observer
{
    public delegate void GameEvent();
    public static GameEvent StartGame;
    public static GameEvent GameOver;

}