namespace GameSystem
{
    public class GameStateMachine
    {
        private IGameState currentGameState;
        private IGameState previousGameState;
        
        public void ChangeGameState(GameState gameState)
        {
            previousGameState = currentGameState;
            switch(gameState)
            {
                case GameState.GAME_OVER:
                    //currentGameState = new GameOverState(uIService, playerService);
                    break;
                case GameState.GAME_PLAY:
                    //currentGameState = new GamePlayState(uIService, playerService);
                    break;
            }
            if(previousGameState!=null)
                previousGameState.OnStateExit();
            currentGameState.OnStateEnter();
        }
        
        public GameState GetGameState()
        {
            return currentGameState.GetState();
        }
    }
}