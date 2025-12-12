using core;
using UnityEngine;

public class CloudIdleState:IState<CloudStateData>
{
    public void Enter()
    {

    }

    public TriggerId? Tick(CloudStateData data)
    {
        return null;
    }
    public void Exit()
    {

    }
}
