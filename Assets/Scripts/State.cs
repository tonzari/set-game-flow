public class State
{
    protected SetGame setGame;
    protected StateMachine stateMachine;

    protected State(SetGame setGame, StateMachine stateMachine)
    {
        this.setGame = setGame;
        this.stateMachine = stateMachine;
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
