using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingState : State
{
    private bool playerWantsToContinue;
    public GameEndingState(SetGame setGame, StateMachine stateMachine) : base(setGame, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        playerWantsToContinue = false;

        Debug.Log("ENTERED STATE: GameEnding");
        
        setGame.GameOver();
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
