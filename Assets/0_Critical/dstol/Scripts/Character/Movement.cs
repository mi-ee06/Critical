using UnityEngine;
/*
 * 行動に関する変数、メソッド、は全部ここにある
 */
public class Movement : MonoBehaviour
{
    [SerializeField] private bool canMove; //行動可能

    private float lateralMovement; //右左行動入力
    private bool jumpInput; //ジャンプ入力
    private bool jumpHeld; //ジャンプボタン長押ししてるか
    private bool jumpReleased; //ジャンプ入力が消えたらこれが一瞬だけTrueになる。長押しの高いジャンプのメソッドに使う
    private bool stepInput; //ステップ入力
    private int directionFaced;

    [SerializeField] private Character owner;//どのキャラに繋がってる

    [SerializeField] private float speed; //右左行動の速さ
    [SerializeField] private float jumpPower; //ジャンプの最初速度
    [SerializeField] private float conservedVerticalMomentum; /* ０から１までにしてください
                                                               * ０なら、上向速度はどんなに高くても、ジャンプしたら普通のジャンプ速度になる。
                                                               * １だったら、新しい上向速度はジャンプ＋前の速度になる*/
    [SerializeField] private float stepDistance;　// ステップ距離
    [SerializeField] private float stepSpeed; //ステップ速度
    [SerializeField] private bool canStepInAir; //キャラは空中でステップできるか
    [SerializeField] private float stepCooldown; //ステップ後あと何秒にまたステップできるか
    [SerializeField] private bool canStep; //今ステップできるか
    private float stepInitialPosition; //ステップし始めた時にどこにいる
    private bool stepping; //今ステップ中か
    private int stepDirection; //ー１：左、１：右

    [SerializeField] private Rigidbody rb;

    [SerializeField] private bool grounded; //地面に立ってるか、ジャンプ回数を数えるに使う
    [SerializeField] private float groundedCheckDistance;　//groundedを調べるRaycastはどこまで進む
    [SerializeField] private LayerMask groundLayer; //地面のレーヤー、groundedのRaycastはこれしか触れない
    [SerializeField] private GameObject feet; //Raycastはどこから出す

    [SerializeField] private bool canJump; //ジャンプが可能か
    [SerializeField] private int maxJumps; //何回ジャンプを連続できるか
    [SerializeField] private int previousJumps; //今まで何回ジャンプした

    [SerializeField] private float fallSpeedModifier; //落ちる速度をこれで乗じる
    [SerializeField] private float terminalVelocity; //落ちる速度の限界

    [SerializeField] private float jumpReleaseModifier; //ジャンプ入力長押しやめたらこの変数で乗じる

    public void Move()
    {
        /*
         * 動く
         */
        if (owner.Alive)
        {
            if (directionFaced != 1 && lateralMovement < 0f)
            {
                directionFaced = 1;
                transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            }
            if(directionFaced != 2 && lateralMovement > 0f)
            {
                directionFaced = 2;
                transform.rotation = Quaternion.Euler(Vector3.zero);
            }
            if (!stepping && canMove)
            {
                rb.linearVelocity = new Vector3(lateralMovement * speed, rb.linearVelocity.y, 0f);
                if (Mathf.Abs(lateralMovement) > 0f && grounded)
                {
                    owner.Animator.SetBool("Moving", true);
                }
                else { owner.Animator.SetBool("Moving", false); }
            }
            if (jumpInput)
            {
                Jump();
            }
            ReduceJumpSpeedOnRelease();
            if (canStep && stepInput && !stepping && (canStepInAir || Grounded()))
            {
                Step();
            }
            ManageStep();
        }
        FallFast();
    }
    public void Jump()
    {
        /*
         * ジャンプする。
         * 先ずはジャンプできるかどうか確認する
         */
        if(canJump)
        {
            owner.Animator.SetBool("Jumping", false);
            owner.Animator.Update(0f);
            owner.Animator.SetBool("Jumping", true);
            Invoke("ResetJumping", 0.5f);
            previousJumps++;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpPower + rb.linearVelocity.y * conservedVerticalMomentum, rb.linearVelocity.z);
        }
    }
    public float LateralMovement
    {
        /*
         * プレーヤーやNPCの入力は右左行動変えられるようにする
         */
        get { return lateralMovement; }
        set { lateralMovement = value; }
    }
    public bool Grounded()
    {
        /*
         * キャラが地面に触れてるか探索する
         */
        grounded = Physics.Raycast(feet.transform.position, Vector3.down, groundedCheckDistance, groundLayer) && rb.linearVelocity.y < jumpPower * 0.3f;
        if(grounded)
        {
            owner.Animator.SetBool("Grounded", true);
            owner.Animator.SetBool("Jumping", false);
        }
        else { owner.Animator.SetBool("Grounded", false); }
            return grounded;
    }
    public void ManageJumps()
    {
        /*
         * ジャンプの回数管理する
         */
        if(!Grounded() && previousJumps == 0)
        {
            previousJumps = 1;
        }
        if(Grounded())
        {
            previousJumps = 0;
        }
        if(previousJumps >= maxJumps)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }
    private void ReduceJumpSpeedOnRelease()
    {
        /*
         * ジャンプ入力の長押しやめたらジャンプの速度が低くなる
         */
        if (rb.linearVelocity.y > 0f && !jumpHeld && jumpReleased)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * jumpReleaseModifier, 0f);
            jumpReleased = false;
        }
    }
    private void FallFast()
    {
        /*
         * 落ちる速度を普通の重力より高くする
         */
        if (rb.linearVelocity.y < 0f)
        {
            rb.linearVelocity = rb.linearVelocity + Vector3.down * Mathf.Pow(fallSpeedModifier, 2) * Time.deltaTime;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -terminalVelocity, 0f), 0f);
        }
    }
    private void Step()
    {
        Debug.Log("Stepping");
        stepInitialPosition = transform.position.x;
        if(lateralMovement > 0f)
        {
            stepDirection = 1;
        }
        if(lateralMovement < 0f)
        {
            stepDirection = -1;
        }
        rb.linearVelocity = rb.linearVelocity + Vector3.right * stepDirection * stepSpeed * 1.1f;
        canStep = false;
        canMove = false;
        stepping = true;
        owner.Animator.SetBool("Stepping", true);
    }
    private void ManageStep()
    {
        //ステップの速度を付ける。そしていつステップを止めるか
        if(stepping)
        {
            if (Mathf.Abs(transform.position.x - stepInitialPosition) >= stepDistance || Mathf.Abs(rb.linearVelocity.x) < 0.5f * stepSpeed)
            {
                StopStep();
            }
            rb.linearVelocity = new Vector3(stepDirection * stepSpeed, rb.linearVelocity.y, 0f);
        }
    }
    private void StopStep()
    {
        //ステップを止める
        rb.linearVelocity = Vector3.zero;
        stepping = false;
        owner.Animator.SetBool("Stepping", false);
        Invoke("StepCooldown", stepCooldown);
        stepDirection = 0;
        Debug.Log("Step Complete");
    }
    private void StepCooldown()
    {
        Debug.Log("Resetting Step");
        canStep = true;
        canMove = true;
    }
    private void ResetJumping()
    {
        owner.Animator.SetBool("Jumping", false);
    }
    public bool StepInput
    {
        set { stepInput = value; }
    }
    public bool JumpInput
    {
        /*
         * プレーヤーやNPCがジャンプできるようにする
         */
        get { return jumpInput; }
        set { jumpInput = value; }
    }
    public bool JumpHeld
    {
        set { jumpHeld = value; }
    }
    public bool JumpReleased
    {
        set { jumpReleased = value; }
    }
    public bool Stepping
    {
        set { stepping = value; }
    }
    public Rigidbody Rb
    {
        get { return rb; }
    }
}
