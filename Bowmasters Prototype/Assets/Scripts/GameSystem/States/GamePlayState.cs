﻿namespace GameSystem
{
    public class GamePlayState : IGameState
    {
        
        
        public void OnStateEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnStateExit()
        {
            throw new System.NotImplementedException();
        }

        public GameState GetState()
        {
            return GameState.GAME_PLAY;
        }
    }
}