using core;
using UnityEngine;

public class BossStateData:IStateData<BossStateData>
{
    private readonly SlimeState slimeState;
    private readonly StateId slimeId = new("slime");
    public readonly TriggerId SlimeTrigger = new("slimeTrigger");

    private readonly CloudState cloudState;
    private readonly StateId cloudId = new("cloud");
    public readonly TriggerId CloudTrigger = new("cloudTrigger");

    public BossStateData(SlimeState slimeState,CloudState cloudState)
    {
        this.slimeState = slimeState;
        this.cloudState = cloudState;
    }
    public (StateId,IState<BossStateData>)[] GetStates()
    {
        return new (StateId, IState<BossStateData>)[]
        {
            (slimeId,slimeState),
            (cloudId,cloudState)
        };
    }
    public (StateId, TriggerId, StateId)[] GetTransitions()
    {
        return new (StateId, TriggerId, StateId)[]
        {
            (slimeId,CloudTrigger,cloudId),
            (cloudId,SlimeTrigger,slimeId)
        };
    }
    public StateId GetInitStateId()
    {
        return slimeId;
    }
}
