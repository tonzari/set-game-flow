using UnityEngine;

public class InitializeGameState : State
{
    private bool startGame;
    [SerializeField] private string startMessage = "Welcome to SET! How many players are there?";

    public InitializeGameState(SetGame setGame) : base(setGame)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        setGame.Interface.SetGameStatusText(startMessage);
        startGame = false;
    }

    public override void Exit()
    {
        base.Exit();
        
        setGame.CreatePlayerList();
        setGame.ShuffleCards();
        setGame.DealCards(12);
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
            
            
            setGame.ChangeState(setGame.waitingForPlayerCall);
        }
    }
}
