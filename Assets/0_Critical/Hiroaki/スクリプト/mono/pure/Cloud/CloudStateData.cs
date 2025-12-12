using core;
using UnityEngine;

public class CloudStateData:IStateData<CloudStateData>
{
    private readonly CloudWaitState _cloudWaitState;
    private readonly StateId waitState = new("cloudWait");
    public readonly TriggerId waitTrigger = new("cloudWaitTrigger");

    private readonly CloudIdleState _cloudIdleState;
    private readonly StateId idleState = new("cloudIdle");
    public readonly TriggerId idleTrigger = new("cloudIdleTrigger");
    public CloudStateData(CloudWaitState cloudWaitState)
    {
        _cloudWaitState = cloudWaitState;
    }
    public (StateId,IState<CloudStateData>)[] GetStates()
    {
        return new (StateId, IState<CloudStateData>)[]
        {
            (waitState, _cloudWaitState),
        };
    }
    public (StateId, TriggerId, StateId)[] GetTransitions()
    {
        return new(StateId, TriggerId, StateId)[]
        {

        };
    }
    public StateId GetInitStateId()
    {
        return waitState;
    }
}
