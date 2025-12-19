using core;
using UnityEngine;

public class IdleState:IState<SlimeStateData>
{
    private SlimeRefs _refs;
    private float stopTime;
    private OnRoom _onRoom;
    public IdleState(SlimeRefs refs,OnRoom onRoom)
    {
        _refs = refs;
        _onRoom = onRoom;
    }
    public void Enter()
    {
        _refs.animator.Play("Idle");
    }
    public TriggerId? Tick(SlimeStateData data)
    {
        if (_onRoom.OnBossRoom)
        {
            stopTime += Time.deltaTime;
            if (stopTime > 1)
            {
                return data.RushTrigger;
            }
        }
        return null;
    }
    public void Exit()
    {
        stopTime = 0;
    }
}
