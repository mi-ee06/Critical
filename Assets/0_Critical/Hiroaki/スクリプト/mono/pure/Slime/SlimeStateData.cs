using core;

public class SlimeStateData:IStateData<SlimeStateData>
{
    private readonly IdleState idleState;
    private readonly StateId idleId = new("idle");
    public readonly TriggerId IdleTrigger = new("idleTrigger");

    private readonly RushState rushState;
    private readonly StateId rushId = new("rush");
    public readonly TriggerId RushTrigger = new("rushTrigger");

    private readonly JumpState jumpState;
    private readonly StateId jumpId = new("jump");
    public readonly TriggerId JumpTrigger = new("JumpTrigger");

    private readonly ReturnState returnState;
    private readonly StateId returnId = new("return");
    public readonly TriggerId ReturnTrigger = new("ReturnTrigger");
    
    public SlimeStateData(IdleState idleState,RushState rushState,JumpState jumpState,ReturnState returnState)
    {
        this.idleState = idleState;
        this.rushState = rushState;
        this.jumpState = jumpState;
        this.returnState = returnState;
    }
    public (StateId, IState<SlimeStateData>)[] GetStates()
    {
        return new (StateId, IState<SlimeStateData>)[]
        {
            (idleId,idleState),
            (rushId,rushState),
            (jumpId,jumpState),
            (returnId,returnState)
        };
    }

    public (StateId, TriggerId, StateId)[] GetTransitions()
    {
        return new (StateId, TriggerId, StateId)[]
        {
            (idleId,RushTrigger,rushId),
            (rushId,JumpTrigger,jumpId),
            (jumpId,ReturnTrigger,returnId),
            (returnId,IdleTrigger,idleId)
        };
    }
    public StateId GetInitStateId()
    {
        return idleId;
    }
}
