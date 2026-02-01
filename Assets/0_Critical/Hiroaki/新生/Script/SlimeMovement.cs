using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class SlimeMovement
{
    Transform _slime;
    Animator _animator;

    public SlimeMovement(Transform slime, Animator animator)
    {
        _slime = slime;
        _animator = animator;
    }

    async public UniTask Rush(Transform target)
    {
        //PreRush‚ðŽn‚ß‚é
        _animator.SetTrigger(SlimeAction.PreRush.ToString());

        //PreRuah‚É“ü‚é
        await intoAnime(SlimeAction.PreRush);

        //PreRush‚©‚ç”²‚¯‚é
        await outAnime(SlimeAction.PreRush);

        //Rush‚ðŽn‚ß‚é
        _animator.SetTrigger(SlimeAction.Rush.ToString());

        //Rush‚É“ü‚é
        await intoAnime(SlimeAction.Rush);

        float duration = _animator.GetCurrentAnimatorStateInfo(0).length;

        await _slime.DOMoveX(target.position.x, duration).ToUniTask();

        //Rush‚©‚ç”²‚¯‚é
        await outAnime(SlimeAction.Rush);

        //ReturnRush‚ðŽn‚ß‚é
        _animator.SetTrigger(SlimeAction.ReturnRush.ToString());

        //ReturnRush‚É“ü‚é
        await intoAnime(SlimeAction.ReturnRush);
        //ReturnRush‚©‚ç”²‚¯‚é
        await outAnime(SlimeAction.ReturnRush);
    }

    async private UniTask intoAnime(SlimeAction action)
    {
        await UniTask.WaitUntil(() =>
        {
            var state = _animator.GetCurrentAnimatorStateInfo(0);
            return state.IsName(action.ToString());
        });
        Debug.Log(action.ToString() + "‚É“ü‚Á‚½");
    }

    async private UniTask outAnime(SlimeAction action)
    {
        await UniTask.WaitUntil(() =>
        {
            var state = _animator.GetCurrentAnimatorStateInfo(0);
            return !state.IsName(action.ToString());
        });
        Debug.Log(action.ToString() + "‚©‚ç”²‚¯‚½");
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
