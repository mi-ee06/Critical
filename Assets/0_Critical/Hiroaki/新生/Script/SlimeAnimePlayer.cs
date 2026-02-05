using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class SlimeAnimePlayer : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;

    [Header("Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float JumpUpSpeed;
    [SerializeField] private float JumpDownSpeed;
    [SerializeField] private float checkDistance;
    [SerializeField] private float wallStopDistance;
    [SerializeField] private float ceilingStopDistance;

    [Header("Layers")]
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask ceilingLayer;

    private Vector3 facingDir = Vector3.right;
    private Transform parent;
    private CancellationTokenSource cts;

    private void Start()
    {
        cts = new CancellationTokenSource();
    }

    private void OnDestroy()
    {
        cts.Cancel();
        cts.Dispose();
    }


    public void SetTrans(Transform transform) => parent = transform;

    public void StartRush()
    {
        UpdateDirection();
        animator.SetTrigger(SlimeTrigger.PreRush.ToString());
    }

    public void EndPreRush()
    {
        animator.SetTrigger(SlimeTrigger.Rush.ToString());
        Rush().Forget();
    }

    public void EndReturnRush()
    {
        UpdateDirection();
        if (IsPlayerInDirection(facingDir, out float distance))
        {
            StartJump(distance).Forget();
        }
        else
        {
            StartRush();
        }
    }

    async private UniTask StartJump(float distance)
    {
        UpdateDirection();
        animator.SetTrigger(SlimeTrigger.Jump.ToString());
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(SlimeTrigger.Jump.ToString()))
        {
            await UniTask.Yield(cts.Token);
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.4)
        {
            await UniTask.Yield(cts.Token);
        }

        float moved = 0f;

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.65)
        {
            var step = jumpSpeed * Time.deltaTime;
            parent.position += facingDir * step;
            parent.position += Vector3.up * JumpUpSpeed * Time.deltaTime;
            moved += step;
            if (moved > distance || GetDistanceToCeiling()<ceilingStopDistance)
            {
                break;
            }
            await UniTask.Yield(cts.Token);
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.75)
        {
            await UniTask.Yield(cts.Token);
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            parent.position -= Vector3.up * JumpDownSpeed * Time.deltaTime;
            if (parent.position.y < 0)
            {
                Vector3 a= parent.position;
                a.y = 0;
                parent.position = a;
                break;
            }
            await UniTask.Yield(cts.Token);
        }

        Vector3 b = parent.position;
        b.y = 0;
        parent.position = b;

        animator.SetTrigger(SlimeTrigger.ReturnJump.ToString());
    }

    public void EndReturnJump()
    {
        StartRush();
    }


    private async UniTask Rush()
    {
        while (GetDistanceToWall(facingDir) > wallStopDistance)
        {
            parent.position += facingDir * speed * Time.deltaTime;
            await UniTask.Yield(cts.Token);
        }

        animator.SetTrigger(SlimeTrigger.ReturnRush.ToString());
    }

    public void UpdateDirection()
    {
        float rightDist = GetDistanceToWall(Vector3.right);
        float leftDist = GetDistanceToWall(Vector3.left);

        facingDir = rightDist > leftDist ? Vector3.right : Vector3.left;
        transform.forward = facingDir;
    }

    private float GetDistanceToWall(Vector3 direction)
    {
        if (Physics.Raycast(parent.position, direction, out RaycastHit hit, checkDistance, wallLayer))
            return hit.distance;

        return checkDistance;
    }

    private bool IsPlayerInDirection(Vector3 direction, out float distance)
    {
        if (Physics.Raycast(parent.position, direction, out RaycastHit hit, checkDistance, playerLayer))
        {
            distance = hit.distance;
            return true;
        }

        distance = 0f;
        return false;
    }

    private float GetDistanceToCeiling()
    {
        if(Physics.Raycast(parent.position,Vector3.up,out RaycastHit hit, checkDistance, ceilingLayer))
        {
            return hit.distance;
        }
        return checkDistance;
    }
}

public enum SlimeTrigger
{
    PreRush,
    Rush,
    ReturnRush,
    Jump,
    ReturnJump
}
