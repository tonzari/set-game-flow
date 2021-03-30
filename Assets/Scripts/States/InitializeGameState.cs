using UnityEngine;

public class InitializeGameState : State
{
    private bool startGame;
    [SerializeField] private string startMessage = "Welcome to SET! Press the space bar to begin.";

    public InitializeGameState(SetGame setGame) : base(setGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("ENTERED STATE: InitializeGame");

        setGame.CreatePlayerList();
        setGame.ShuffleCards();
        setGame.DealCards(12);
        startGame = false;

        setGame.Interface.SetGameStatusText(startMessage);
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
            setGame.ChangeState(setGame.waitingForPlayerCall);
        }
    }
}
