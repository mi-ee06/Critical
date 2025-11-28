using core;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class JumpState:IState<SlimeStateData>
{
    private float firstY;
    private float distance;

    private SlimeRefs _refs;
    private readonly Transform _playerTf;

    private float JumpStopCount;
    public JumpState(SlimeRefs refs, Transform playerTf)
    {
        _refs = refs;
        _playerTf = playerTf;
    }

    public void Enter()
    {
        if (_refs.target.localPosition.x > _playerTf.localPosition.x)
        {
            _refs.target.localRotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            _refs.target.localRotation = Quaternion.Euler(0, 90, 0);
        }
        distance = _playerTf.localPosition.x - _refs.target.localPosition.x;
        firstY =_refs.target.localPosition.y;
        _refs.animator.Play("Jump");
    }
    public TriggerId? Tick(SlimeStateData data)
    {
        var stateInfo = _refs.animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >0.3 && stateInfo.normalizedTime<0.6)
        {
            Vector3 a = _refs.target.localPosition;
            a.y += 20 * Time.deltaTime;
            a.x += distance * Time.deltaTime;
            _refs.target.localPosition = a;
        }
        //if(stateInfo.normalizedTime>0.6 && stateInfo.normalizedTime<0.7)
        //{
        //    Vector3 b = _refs.core.localPosition;
        //    b.z += 0.07f;
        //    _refs.core.localPosition = b;
        //}

        if (stateInfo.normalizedTime > 0.7 && stateInfo.normalizedTime<1)
        {
            Vector3 a = _refs.target.localPosition;
            a.y -= 20 * Time.deltaTime;
            _refs.target.localPosition = a;
        }
        if(stateInfo.normalizedTime >= 1)
        {
            JumpStopCount += Time.deltaTime;
            if (JumpStopCount > 1.5)
            {
                return data.ReturnTrigger;
            }
        }
        if (_refs.target.localPosition.x > 14)
        {
            Vector3 a=_refs.target.localPosition;
            a.x = 14;
            _refs.target.localPosition = a;
        }
        if (_refs.target.localPosition.x <-14)
        {
            Vector3 a = _refs.target.localPosition;
            a.x = -14;
            _refs.target.localPosition = a;
        }

        return null;
    }
    public void Exit()
    {
        Vector3 a=_refs.target.localPosition;
        a.y = firstY;
        _refs.target.localPosition = a;
        JumpStopCount = 0;
    }
}