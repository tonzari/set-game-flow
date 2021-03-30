using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSetsAvailableState : State
{
    [SerializeField] private string startMessage = "There are NO undiscovered sets here. Press space to Deal 3 more cards.";
    private bool userPressedKey;

    public NoSetsAvailableState(SetGame setGame) : base(setGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        userPressedKey = false;

        setGame.Interface.SetGameStatusText(startMessage);
        setGame.DealCards(3);
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
            userPressedKey = true;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (userPressedKey)
        {
            setGame.ChangeState(setGame.waitingForPlayerCall);
        }
    }
}
