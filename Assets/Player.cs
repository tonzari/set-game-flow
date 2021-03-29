[System.Serializable]
public class Player
{
    public string PlayerName { get; set; }
    public int Score { get; set; }

    public Player(string playerName)
    {
        PlayerName = playerName;
    }
}
