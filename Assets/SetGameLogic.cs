using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetGameLogic : MonoBehaviour
{
    private int _cardDeck = 81;
    private int _cardsInPlay = 0;

    // State, of sorts
    private bool _isGameOver = false;
    private bool _isWaitingForPlayerInput = false;

    private Player _playerOne;
    private Player _playerTwo;

    private void GameInit()
    {
        _playerOne = new Player("Antonio"); // You should change this immediately
        _playerTwo = new Player("Hamburger"); // You should change this immediately


        ShuffleCards(); 
        DealCards(12);
       
        Debug.Log("Welcome to SET! You may start playing. To call SET, press the 1 key.");
        _isWaitingForPlayerInput = true;
    }

    private void MainGameLoop(bool isThereASet, Player playerThatCalled)
    {
        _isWaitingForPlayerInput = false;

        if (isThereASet)
        {
            playerThatCalled.Score++;
            _cardsInPlay -= 3;

            Debug.Log(playerThatCalled.PlayerName + " calls SET! Take your cards. " + playerThatCalled.PlayerName + " has " + playerThatCalled.Score + " points.");

            if (_cardsInPlay >= 12)
            {
                HandleExcessCardsInPlayTurn();
            }
            else
            {
                if (_cardDeck >= 3)
                {
                    DealCards(3);
                    //float randBool = UnityEngine.Random.value;
                    //MainGameLoop(randBool > 0.5);
                    //MainGameLoop(true);
                    _isWaitingForPlayerInput = true;
                    return;
                }
                else
                {
                    Debug.Log("Hold on now! This might be the end of the game. Are there any sets left?");

                    float areThereUndiscoveredSetsEndOfGame = UnityEngine.Random.value;

                    if (areThereUndiscoveredSetsEndOfGame > 0.5f)
                    {
                        Debug.Log("Yep, there's a set/there are sets left. Press your number to call SET!");
                        //MainGameLoop(true);
                        _isWaitingForPlayerInput = true;
                        return;

                    }
                    else
                    {
                        GameOverSequence();
                    }
                }
            }
        }
        else
        {
            Debug.Log("NO! There are NOT any undiscovered sets. Dealing 3 more cards.");
            DealCards(3);
            //float randBool = UnityEngine.Random.value;
            // MainGameLoop(randBool > 0.5);
            //MainGameLoop(true);
            Debug.Log("There are "+ _cardsInPlay +"cards in play. Call Set with your number key.");
            _isWaitingForPlayerInput = true;
            return;
        }

    }

    private void HandleExcessCardsInPlayTurn()
    {
        Debug.Log("There are still " + _cardsInPlay + " cards in play on the table.");
        //float randBool = UnityEngine.Random.value;
        //MainGameLoop(randBool > 0.5);
        //MainGameLoop(true);
        Debug.Log("Remember to press your number key to call SET!");
        _isWaitingForPlayerInput = true;
        return;
    }

    private void GameOverSequence()
    {
        Debug.Log("No sets left. Game over!");
        Debug.Log(_playerOne.PlayerName + " has " + _playerOne.Score + " points.");
        Debug.Log(_playerTwo.PlayerName + " has " + _playerTwo.Score + " points.");
        _isGameOver = true;
        Debug.Log("Do you want to play again? You have to restart the program. Sorry.");
    }

    private void ShuffleCards()
    {
        //this doesn't actually do anything
    }

    private void DealCards(int howManyCards)
    {
        //we should just subtract from the main deck
        //and add to cardsInPlay

        _cardDeck -= howManyCards;
        _cardsInPlay += howManyCards;
    }

    private void Start()
    {
        GameInit();
    }

    private void Update()
    {
        //float randBool = UnityEngine.Random.value;
        //MainGameLoop(randBool > 0.5);
        if (!_isGameOver && _isWaitingForPlayerInput)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                MainGameLoop(true, _playerOne);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                MainGameLoop(true, _playerTwo);
            }
        }
        
    }
}
