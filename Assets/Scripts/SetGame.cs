using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetGame : StateMachine
{
    [SerializeField] private SetUI ui;

    public SetUI Interface => ui;
        
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
        initializeGame = new InitializeGameState(this);
        waitingForPlayerCall = new WaitingForPlayerCallState(this);
        gameEnding = new GameEndingState(this);
        userScores = new UserScoresState(this);
        noSetsAvailable = new NoSetsAvailableState(this);

        Initialize(initializeGame);
    }

    private void Update()
    {
        CurrentState.HandleInput();
        CurrentState.LogicUpdate();
    }

    public void CreatePlayerList()
    {
        Players = new List<Player>();
        int playerCount = GetPlayerCount();

        for (int i = 0; i <= playerCount; i++)
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

    public string GetPlayerName(int i)
    {
        // This is just a dumby method. Later we will get the name through the game UI
        string playerNumber = i.ToString();
        return $"Player {playerNumber}";
    }

    public int GetPlayerCount()
    {
        //This should get a number set by the user through the UI
        return 4;
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

        Debug.Log($"No sets left. Game over! The winner is {highScoreHolder}. Press space bar to play again.");
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
