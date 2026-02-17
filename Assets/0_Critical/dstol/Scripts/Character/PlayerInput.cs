using UnityEngine;
/*
 * プレーヤーの入力を読み取りする
 */
public class PlayerInput
{
    [SerializeField] Character owner;
    [SerializeField] private float lateralInput;//右左行動入力
    [SerializeField] private bool jumpInput;
    private bool attackInput;

    private bool jumpHeld;
    public bool previousJumpHeld;
    private bool stepInput;

    public void ReadMovementInput()
    {
        /*
         * プレーヤーの動きに関する入力を読む
         */
        lateralInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetButtonDown("Jump");
        jumpHeld = Input.GetButton("Jump");
        stepInput = Input.GetButton("Fire3");
        if(!jumpHeld && jumpHeld != previousJumpHeld)
        {
            owner.CharacterMovement.JumpReleased = true;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            attackInput = true;
        }
        else { attackInput = false; }
        previousJumpHeld = jumpHeld;
    }
    public void ApplyInput()
    {
        /*
         * 読んだ入力をMovementクラスに通信する
         */
        owner.CharacterMovement.LateralMovement = lateralInput;
        owner.CharacterMovement.JumpInput = jumpInput;
        owner.CharacterMovement.JumpHeld = jumpHeld;
        owner.CharacterMovement.StepInput = stepInput;

        if(attackInput)
        {
            owner.Inventory.DelayedAttack();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            owner.GameManager.TogglePause();
        }
    }

    public Character Owner
    {
        set { owner = value; }
    }
}
