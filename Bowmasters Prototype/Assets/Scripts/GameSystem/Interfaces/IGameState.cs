namespace GameSystem
{
    public interface IGameState
    {
        void OnStateEnter();
        void OnStateExit();

        GameState GetState();
    }
}