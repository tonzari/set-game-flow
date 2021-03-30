using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class WaitingForPlayerCallState : State
{
    [SerializeField] private string startMessage = "Any player may call SET! See any sets?";
    private bool playerCalledSet;
    private int playerNumber;
    private bool setExists => setGame.CheckSetExists();
    private bool playerSetIsValid => setGame.CheckUserIsCorrect();


    public WaitingForPlayerCallState(SetGame setGame) : base(setGame)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        playerCalledSet = false;
        
        setGame.Interface.SetGameStatusText(startMessage);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerCalledSet = true;
            playerNumber = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerCalledSet = true;
            playerNumber = 2;
        }
        else
        {
            playerCalledSet = false;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (playerCalledSet)
        {
            setGame.playerThatCalledSet = setGame.Players[playerNumber];

            if (setExists && playerSetIsValid)
            {
                setGame.ChangeState(setGame.userScores);
            }
            else
            {
                setGame.ChangeState(setGame.noSetsAvailable);
            }
        }
    }
}
