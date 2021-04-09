using UnityEngine;
using UnityEngine.UI;

public class InitializeGameState : State
{
    [SerializeField] private string startMessage = "Welcome to SET! How many players are there?";

    public InitializeGameState(SetGame setGame) : base(setGame)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        setGame.Interface.SetGameStatusText(startMessage);
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
        
        // get player count: wait for button click and then take text from input field and set the player count. Validation is bad. Change it.
        setGame.Interface.button.onClick.AddListener(() => setGame.SetPlayerCount(int.Parse(setGame.Interface.inputField.text)));
        
        // for player count, create a player in the list and wait for user input to get the name
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        /*if (startGame)
        {
            setGame.ChangeState(setGame.waitingForPlayerCall);
        }*/
    }
}
