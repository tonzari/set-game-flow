using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetGameLogic : MonoBehaviour
{
    private int _cardDeck = 81;
    private int _cardsInPlay = 0;

    // Game state
    private bool _isGameOver = false;
    private bool _isWaitingForPlayerInput = false;

    private List<Player> _players;
    
    private void Start()
    {
        GameInit();
    }

    private void Update()
    {
        if (!_isGameOver && _isWaitingForPlayerInput)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PlayerCallsSet(_players[0]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PlayerCallsSet(_players[1]);
            }
        }
    }

    private void GameInit()
    {
        UpdatePlayerList();
        ShuffleCards(); 
        DealCards(12);
       
        Debug.Log("Welcome to SET! You may start playing. To call SET, press the 1 key.");
        _isWaitingForPlayerInput = true;
    }

    private void UpdatePlayerList()
    {
        _players = new List<Player>();
        int playerCount = GetPlayerCount();

        for (int i = 1; i <= playerCount; i++)
        {
            string newPlayerName = GetPlayerName(i);
            Player newPlayer = new Player(newPlayerName);
            _players.Add(newPlayer);
        }
    }

    private string GetPlayerName(int i)
    {
        string playerNumber = i.ToString();
        return $"Player {playerNumber}";
    }

    private int GetPlayerCount()
    {
        //This should get a number set by the user through the UI
        return 4;
    }

    private void PlayerCallsSet(Player playerThatCalledSet)
    {
        _isWaitingForPlayerInput = false;

        if (CheckSetExists() && CheckUserCorrectlyCalledSet())
        {
            RemoveCalledSetCards();
            playerThatCalledSet.Score++;

            Debug.Log(playerThatCalledSet.PlayerName + " calls SET! Take your cards. " + playerThatCalledSet.PlayerName + " has " + playerThatCalledSet.Score + " points.");

            if (_cardsInPlay >= 12)
            {
                HandleExcessCardsInPlayTurn();
            }
            else
            {
                if (_cardDeck >= 3)
                {
                    DealCards(3);
                    _isWaitingForPlayerInput = true;
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

                    }
                    else
                    {
                        GameOver();
                    }
                }
            }
        }
        else
        {
            Debug.Log("There are NOT any undiscovered sets. Dealing 3 more cards.");
            DealCards(3);
            Debug.Log("There are "+ _cardsInPlay +" cards in play. Call Set with your number key.");
            _isWaitingForPlayerInput = true;
            return;
        }

    }

    private void RemoveCalledSetCards()
    {
        _cardsInPlay -= 3;
    }

    private bool CheckUserCorrectlyCalledSet()
    {
        // This should process if the user correctly called a set
        return true;
    }

    private bool CheckSetExists()
    {
        // this should process the current cards to make sure a set actually exists.
        // for now, we just always say it is true.
        return true;
    }

    private void HandleExcessCardsInPlayTurn()
    {
        Debug.Log("There are still " + _cardsInPlay + " cards in play on the table.");
        Debug.Log("Remember to press your number key to call SET!");
       
        _isWaitingForPlayerInput = true;
    }

    private void GameOver()
    {
        int highScore = 0;
        string highScoreHolder = "";

        foreach (Player player in _players)
        {
            if (player.Score > highScore)
            {
                highScore = player.Score;
                highScoreHolder = player.PlayerName;
            }

            Debug.Log($"{player.PlayerName} has {player.Score} points.");
        }

        _isGameOver = true;

        Debug.Log($"No sets left. Game over! The winner is {highScoreHolder}");
    }

    private void ShuffleCards()
    {
        //this doesn't actually do anything
    }

    private void DealCards(int howManyCards)
    {
        //subtract from the main deck
        //add them to cardsInPlay

        _cardDeck -= howManyCards;
        _cardsInPlay += howManyCards;
    }
}
