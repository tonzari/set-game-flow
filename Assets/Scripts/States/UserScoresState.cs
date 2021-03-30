using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UserScoresState : State
{
    private string startMessage;
    private bool userPressedKey;

    public UserScoresState(SetGame setGame) : base(setGame)
    {
    }

    public override void Enter()
    {
        base.Enter();

        userPressedKey = false;
        setGame.UserCollectsCardsTheyWon();
        setGame.playerThatCalledSet.Score++;

        startMessage = $"{setGame.playerThatCalledSet.PlayerName} calls SET! Nice job! Take your cards. {setGame.playerThatCalledSet.PlayerName} now has {setGame.playerThatCalledSet.Score} points.";
        
        setGame.Interface.SetGameStatusText(startMessage);
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
            userPressedKey = false;
            
            if (setGame.CardsInPlay >= 12)
            {
                Debug.Log("No need to add more cards! There are still " + setGame.CardsInPlay + " cards in play on the table.");
                Debug.Log("Remember to press your number key to call SET!");

                setGame.ChangeState(setGame.waitingForPlayerCall);
            }
            else
            {
                if (setGame.CardDeck >= 3)
                {
                    setGame.DealCards(3);

                    setGame.ChangeState(setGame.waitingForPlayerCall);
                }
                else
                {
                    Debug.Log("Hold up! No cards left to add to the cards in play! Are there any sets left?");

                    // RANDOMIZE a bool so the game can actually end
                    float areThereUndiscoveredSetsEndOfGame = UnityEngine.Random.value;

                    if (setGame.CheckSetExists() && areThereUndiscoveredSetsEndOfGame > 0.5f)
                    {
                        Debug.Log("Yep, there's a set/there are sets left. Press your number to call SET!");

                        setGame.ChangeState(setGame.waitingForPlayerCall);
                    }
                    else
                    {
                        setGame.ChangeState(setGame.gameEnding);
                    }
                }
            }
        }
    }
}
