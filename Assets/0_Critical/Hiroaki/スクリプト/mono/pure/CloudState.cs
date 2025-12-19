using core;
using UnityEngine;

public class CloudState:IState<BossStateData>
{
    private readonly StateMachine<CloudStateData> _cloudSM;
    public CloudState(StateMachine<CloudStateData> cloudSM)
    {
        _cloudSM = cloudSM;
    }
    public void Enter()
    {
        _cloudSM.Enter();
    }
    public TriggerId? Tick(BossStateData data)
    {
        _cloudSM.Tick();
        return null;
    }
    public void Exit()
    {
        _cloudSM.Exit();
    }
}
