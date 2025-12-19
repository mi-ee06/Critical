using UnityEngine;
using core;
public class ReturnState:IState<SlimeStateData>
{
    private SlimeRefs _refs;

    private Vector3 fixedPosition_1 = new (-10,-7,0);
    private Vector3 fixedPosition2 = new(10,-7,0);
    private Vector3 targetPosition;
    private float distance;

    private float firstY;

    public ReturnState(SlimeRefs refs)
    {
        _refs = refs;
    }

    public void Enter()
    {
        if (_refs.target.localPosition.x < 0)
        {
            targetPosition = fixedPosition_1;
        }
        else
        {
            targetPosition = fixedPosition2;
        }
        distance=targetPosition.x -_refs.target.localPosition.x;
        firstY = _refs.target.localPosition.y;
        _refs.animator.Play("ReturnJump");
    }
    public TriggerId? Tick(SlimeStateData data)
    {
        var stateInfo = _refs.animator.GetCurrentAnimatorStateInfo(0);
        Vector3 a = _refs.target.localPosition;
        a.x += distance*8/10 * Time.deltaTime;
        //if (stateInfo.normalizedTime < 0.1)
        //{
        //    Vector3 b = _refs.core.localPosition;
        //    b.z -= 0.07f;
        //    _refs.core.localPosition = b;
        //}

        if (stateInfo.normalizedTime <0.45)
        {
            a.y += 3 * Time.deltaTime;
            _refs.target.localPosition = a;
        }
        else
        {
            a.y -= 3 * Time.deltaTime;
            _refs.target.localPosition = a;
        }


        if (stateInfo.normalizedTime >= 0.9)
        {
            return data.IdleTrigger;
        }
        return null;
    }
    public void Exit()
    {
        Vector3 a = _refs.target.localPosition;
        a.y = firstY;
        _refs.target.localPosition = a;
    }
}
