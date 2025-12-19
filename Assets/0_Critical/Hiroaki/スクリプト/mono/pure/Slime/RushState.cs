using core;
using UnityEngine;

public class RushState:IState<SlimeStateData>
{
    private SlimeRefs _refs;

    private readonly Transform _playerTf;

    private float PreStopCount;
    private float ReturnStopCount;

    private int speed=40;
    public RushState(SlimeRefs refs, Transform playerTf)
    {
        _refs = refs;
        _playerTf = playerTf;
    }

    public void Enter()
    {
        if(_refs.target.localPosition.x>_playerTf.localPosition.x)
        {
            _refs.target.localRotation = Quaternion.Euler(0, -90, 0);
            speed = -40;
        }
        else
        {
            _refs.target.localRotation = Quaternion.Euler(0, 90, 0);
            speed = 40;
        }
            _refs.animator.Play("PreRush");
    }
    public TriggerId? Tick(SlimeStateData data)
    {
        var _stateInfo = _refs.animator.GetCurrentAnimatorStateInfo(0);
        if (_stateInfo.IsName("PreRush"))
        {
            if (_stateInfo.normalizedTime >= 1)
            {
                PreStopCount+=Time.deltaTime;
                if (PreStopCount > 1)
                {
                    _refs.animator.Play("AttackRush");
                }
            }
        }
        if (_stateInfo.IsName("AttackRush"))
        {
            Vector3 a = _refs.target.localPosition;
            a.x+=speed*Time.deltaTime;
            _refs.target.localPosition = a;

            if (_stateInfo.normalizedTime >= 1)
            {
                _refs.animator.Play("ReturnRush");
            }
        }
        if (_stateInfo.IsName("ReturnRush"))
        {
            if (_stateInfo.normalizedTime >= 1)
            {
                ReturnStopCount += Time.deltaTime;
                if (ReturnStopCount > 1)
                {
                    return data.JumpTrigger;
                }
            }
        }
        if (_refs.target.localPosition.x > 14 || _refs.target.localPosition.x < -14)
        {
            return data.JumpTrigger;
        }

        return null;
    }
    public void Exit()
    {
        PreStopCount = 0;
        ReturnStopCount = 0;
    }
}