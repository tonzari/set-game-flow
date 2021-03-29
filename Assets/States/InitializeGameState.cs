using UnityEngine;

public class InitializeGameState : State
{
    private bool startGame;

    public InitializeGameState(SetGame setGame, StateMachine stateMachine) : base(setGame, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("ENTERED STATE: InitializeGame");

        setGame.ResetGameData();
        setGame.CreatePlayerList();
        setGame.ShuffleCards();
        setGame.DealCards(12);
        startGame = false;

        Debug.Log("Welcome to SET! Press the space bar to begin.");
    }

    public override void Exit()
    {
        Debug.Log("You may start playing. To call SET, press your number key.");
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startGame = true;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (startGame)
        {
            stateMachine.ChangeState(setGame.waitingForPlayerCall);
        }
    }
}
