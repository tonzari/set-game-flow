using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSetsAvailableState : State
{
    public NoSetsAvailableState(SetGame setGame, StateMachine stateMachine) : base(setGame, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("There are NO undiscovered sets here. Dealing 3 more cards!");
        setGame.DealCards(3);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("There are " + setGame.CardsInPlay + " cards in play. Call Set with your number key.");
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        stateMachine.ChangeState(setGame.waitingForPlayerCall);
    }
}
