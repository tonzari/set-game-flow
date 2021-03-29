using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetGame : MonoBehaviour
{
    public StateMachine gameSM;
    public State initializeGame;
    public State waitingForPlayerCall;
    public State gameEnding;
    public State userScores;
    public State noSetsAvailable;

    public int CardDeck = 81;
    public int CardsInPlay = 0;

    public List<Player> Players;
    public Player playerThatCalledSet = new Player();
    
    private void Start()
    {
        gameSM = new StateMachine();

        initializeGame = new InitializeGameState(this, gameSM);
        waitingForPlayerCall = new WaitingForPlayerCallState(this, gameSM);
        gameEnding = new GameEndingState(this, gameSM);
        userScores = new UserScoresState(this, gameSM);
        noSetsAvailable = new NoSetsAvailableState(this, gameSM);

        gameSM.Initialize(initializeGame);
    }

    private void Update()
    {
        gameSM.CurrentState.HandleInput();
        gameSM.CurrentState.LogicUpdate();
    }

    public void CreatePlayerList()
    {
        Players = new List<Player>();
        int playerCount = GetPlayerCount();

        for (int i = 1; i <= playerCount; i++)
        {
            string newPlayerName = GetPlayerName(i);
            Player newPlayer = new Player()
            {
                PlayerName = newPlayerName,
                Score = 0
            };
            Players.Add(newPlayer);
        }
    }

    private string GetPlayerName(int i)
    {
        // This is just a dumby method. Later we will get the name through the game UI
        string playerNumber = i.ToString();
        return $"Player {playerNumber}";
    }

    private int GetPlayerCount()
    {
        //This should get a number set by the user through the UI
        return 4;
    }

    public void PlayerCallsSet(Player playerThatCalledSet)
    {
        if (CheckSetExists() && CheckUserIsCorrect())
        {
            UserCollectsCardsTheyWon();
            playerThatCalledSet.Score++;

            Debug.Log(playerThatCalledSet.PlayerName + " calls SET! Take your cards. " + playerThatCalledSet.PlayerName + " has " + playerThatCalledSet.Score + " points.");

            if (CardsInPlay >= 12)
            {
                HandleExcessCardsInPlayTurn();
            }
            else
            {
                if (CardDeck >= 3)
                {
                    DealCards(3);
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
            Debug.Log("There are "+ CardsInPlay +" cards in play. Call Set with your number key.");
            _isWaitingForPlayerInput = true;
        }

    }

    public void UserCollectsCardsTheyWon()
    {
        CardsInPlay -= 3;
    }

    public bool CheckUserIsCorrect()
    {
        // This should process if the user correctly called a set
        return true;
    }

    public bool CheckSetExists()
    {
        // this should process the current cards to make sure a set actually exists.
        // for now, we just always say it is true.
        return true;
    }

    public void HandleExcessCardsInPlayTurn()
    {
        Debug.Log("No need to add more cards! There are still " + CardsInPlay + " cards in play on the table.");
        Debug.Log("Remember to press your number key to call SET!");
       
        _isWaitingForPlayerInput = true;
    }

    public void GameOver()
    {
        int highScore = 0;
        string highScoreHolder = "";

        foreach (Player player in Players)
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

    public void ShuffleCards()
    {
        //this doesn't actually do anything
    }

    public void DealCards(int howManyCards)
    {
        //subtract from the main deck
        //add them to cardsInPlay

        CardDeck -= howManyCards;
        CardsInPlay += howManyCards;
    }
}
