using UnityEngine;

public class InitializeGameState : State
{
    public InitializeGameState(SetGame setGame, StateMachine stateMachine) : base(setGame, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        setGame.CreatePlayerList();
        setGame.ShuffleCards();
        setGame.DealCards(12);

        Debug.Log("Welcome to SET!");
    }

    public override void Exit()
    {
        Debug.Log("You may start playing. To call SET, press your number key.");
        base.Exit();
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
