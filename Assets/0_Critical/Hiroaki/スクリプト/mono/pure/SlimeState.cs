using core;
using UnityEngine;

public class SlimeState : IState<BossStateData>
{
    private GameObject obj;
    private readonly StateMachine<SlimeStateData> _slimeSM;
    private readonly GameObject _slimePrefab;
    private readonly SlimeRefs _refs;
    private bool defeated;
    private bool make;
    public SlimeState(StateMachine<SlimeStateData> slimeSM, GameObject slimePrefab,SlimeRefs refs)
    {
        _slimeSM = slimeSM;
        _slimePrefab = slimePrefab;
        _refs = refs;
    }

    public void Enter()
    {
        obj = Object.Instantiate(_slimePrefab);
        SlimeController SC = obj.GetComponent<SlimeController>();
        _refs.target = SC.target;
        _refs.animator = SC.animator;
        _refs.normalCore = SC.normalCore;
        _refs.jumpCore = SC.jumpCore;
        _refs.core_normal= SC.core_normal;
        _refs.core_jump= SC.core_jump;
        _refs.core_normal.defeat += def;
        _refs.core_jump.defeat += def;
        _slimeSM.Enter();
    }
    public TriggerId? Tick(BossStateData data)
    {
        _slimeSM.Tick();
        if (make)
        {
            return data.CloudTrigger;
        }
        return null;
    }
    public void Exit()
    {
        make = false;
        Object.Destroy(obj);
        _slimeSM.Exit();
    }
    private void def()
    {
        make = true;
    }
}
