public class State
{
    protected SetGame setGame;

    protected State(SetGame setGame)
    {
        this.setGame = setGame;
    }

    public virtual void Enter()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void Exit()
    {
    }
}
