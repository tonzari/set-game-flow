using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingState : State
{
    private bool playerWantsToContinue;
    public GameEndingState(SetGame setGame) : base(setGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        playerWantsToContinue = false;
        
        int highScore = 0;
        string highScoreHolder = "";
        string startMessage = "";
        
        foreach (Player player in setGame.Players)
        {
            if (player.Score > highScore)
            {
                highScore = player.Score;
                highScoreHolder = player.PlayerName;
            }
        }

        startMessage = $"No sets left. Game over! The winner is {highScoreHolder} with {highScore} points! Press space bar to play again.";
        
        setGame.Interface.SetGameStatusText(startMessage);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerWantsToContinue = true;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (playerWantsToContinue)
        {
            //stateMachine.ChangeState(setGame.initializeGame);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
