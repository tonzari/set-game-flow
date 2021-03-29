using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndingState : State
{
    public GameEndingState(SetGame setGame, StateMachine stateMachine) : base(setGame, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        setGame.GameOver();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
