using core;
using UnityEngine;

public class CloudWaitState:IState<CloudStateData>
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
