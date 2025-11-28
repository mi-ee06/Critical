using core;
using UnityEngine;

public class SlimeState : IState<BossStateData>
{
    private GameObject obj;
    private readonly StateMachine<SlimeStateData> _slimeSM;
    private readonly GameObject _slimePrefab;
    private readonly SlimeRefs _refs;
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
        //_refs.core = SC.core;
        _slimeSM.Enter();
    }
    public TriggerId? Tick(BossStateData data)
    {
        _slimeSM.Tick();
        return null;
    }
    public void Exit()
    {
        Object.Destroy(obj);
        _slimeSM.Exit();
    }
}
