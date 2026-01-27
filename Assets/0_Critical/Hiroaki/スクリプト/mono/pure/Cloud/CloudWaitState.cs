using core;
using UnityEngine;

public class CloudWaitState:IState<CloudStateData>
{
    OnRoom _onRoom;
    public CloudWaitState(OnRoom onRoom)
    {
        _onRoom = onRoom;
    }
    public void Enter()
    {

    }
    public TriggerId? Tick(CloudStateData data)
    {
        if (!_onRoom.OnBossRoom)
        {

        }
        return null;
    }
    public void Exit()
    {

    }
}
