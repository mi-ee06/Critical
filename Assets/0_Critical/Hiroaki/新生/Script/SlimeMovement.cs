using Cysharp.Threading.Tasks;
using UnityEngine;

public class SlimeMovement
{
    Transform _slime;
    Animator _animator;

    async public UniTask Rush()
    {
        _animator.SetTrigger("PreRush");

        await UniTask.WaitUntil(() =>
        {
            var state = _animator.GetCurrentAnimatorStateInfo(0);
            return state.IsName("PreRush");
        });

        await UniTask.WaitUntil(() =>
        {
            var state= _animator.GetCurrentAnimatorStateInfo(0);
            return !state.IsName("PreRush");
        });

        _animator.SetTrigger("Rush");

        await UniTask.WaitUntil(() =>
        {
            var state = _animator.GetCurrentAnimatorStateInfo(0);
            return !state.IsName("Rush");
        });
    }
}

public enum SlimeAction
{
    PreRush,
    Rush,
    ReturnRush,
    Jump,
    JumpReturn
}
