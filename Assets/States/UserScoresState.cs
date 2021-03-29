using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserScoresState : State
{
    private bool moreThanEnoughCards => setGame.CardsInPlay >= 12; //magic number because this is a strict game rule

    public UserScoresState(SetGame setGame, StateMachine stateMachine) : base(setGame, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        setGame.UserCollectsCardsTheyWon();
        setGame.playerThatCalledSet.Score++;

        Debug.Log(setGame.playerThatCalledSet.PlayerName + " calls SET! Take your cards. " + setGame.playerThatCalledSet.PlayerName + " has " + setGame.playerThatCalledSet.Score + " points.");

        if (moreThanEnoughCards)
        {
            Debug.Log("No need to add more cards! There are still " + setGame.CardsInPlay + " cards in play on the table.");
            Debug.Log("Remember to press your number key to call SET!");

            //change state: WAITING STATE
        }
        else
        {
            if (setGame.CardDeck >= 3)
            {
                setGame.DealCards(3); // CHANGE TO WAITING STATE
            }
            else
            {
                Debug.Log("Hold on now! This might be the end of the game. Are there any sets left?");

                float areThereUndiscoveredSetsEndOfGame = UnityEngine.Random.value;

                if (areThereUndiscoveredSetsEndOfGame > 0.5f)
                {
                    Debug.Log("Yep, there's a set/there are sets left. Press your number to call SET!");
                    _isWaitingForPlayerInput = true; // CHANGE TO WAITING STATE

                }
                else
                {
                    GameOver(); // CHANGE TO GAME OVER STATE
                }
            }
        }
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
